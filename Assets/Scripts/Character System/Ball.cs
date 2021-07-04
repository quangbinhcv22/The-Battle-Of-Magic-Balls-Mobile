using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public enum TypeBall
{
    Player,
    Earth,
    Fire,
    Water,
}

public enum StatusBall
{
    Default,
    Rush,
}

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public static float positionBound = 20;

    public TypeBall typeBall;

    public int level = 1;
    public string tagTarget;
    public Health health = new Health();
    public Resistance resistance = new Resistance();
    public MoveSpeed moveSpeed = new MoveSpeed();
    public ThrustForce thrustForce = new ThrustForce();
    public Mana mana = new Mana();
    public bool isCanMove;
    public bool isNormalizedVelocity;
    public int ScoreWhenDie;

    new protected Rigidbody rigidbody;

    private StatusBall status;

    public delegate void BallHealthChangeHandler(Health health);
    public delegate void BallManaChangeHandler(Mana mana);
    public delegate void BallLevelChangeHandler(int level);
    public delegate void EffectDurationHandler(float effectDuration);

    public event BallHealthChangeHandler OnHealthChanged;
    public event BallManaChangeHandler OnManaChanged;
    public event BallLevelChangeHandler OnLevelChanged;
    public event EffectDurationHandler OnEffectDurationCooldown;


    public void OnEnable()
    {
        SetStartFromSvcFile();
    }

    // Start is called before the first frame update
    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        UpdateStat();
        DetectOutBound();
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (IsTarget(collision.gameObject))
        {
            Ball ballCollision = collision.gameObject.GetComponent<Ball>();

            this.CreateThrustTo(ballCollision);
            this.DealDamage(ballCollision);

            this.IncreaseMana(ThrustForce.GetRealThrustForce(this.thrustForce.Current, ballCollision.resistance.Current));

            if (status == StatusBall.Rush)
            {
                status = StatusBall.Default;
                TemporarilyDontMove();
            }
        }
    }

    public void SetStartFromSvcFile()
    {
        CultureInfo cultureEngland = new CultureInfo("en-US");

        string[] statsData = DataManager.Instance.GetStatBall(typeBall);

        tagTarget = statsData[1];

        health.Start = float.Parse(statsData[2], cultureEngland);
        health.PerLevel = float.Parse(statsData[3], cultureEngland);

        resistance.Start = float.Parse(statsData[4], cultureEngland);
        resistance.PerLevel = float.Parse(statsData[5], cultureEngland);

        moveSpeed.Start = float.Parse(statsData[6], cultureEngland);
        moveSpeed.PerLevel = float.Parse(statsData[7], cultureEngland);


        isNormalizedVelocity = bool.Parse(statsData[8]);

        thrustForce.Start = float.Parse(statsData[9], cultureEngland);
        thrustForce.PerLevel = float.Parse(statsData[10], cultureEngland);

        mana.Start = float.Parse(statsData[11], cultureEngland);
        mana.PerLevel = float.Parse(statsData[12], cultureEngland);

        ScoreWhenDie = int.Parse(statsData[13], cultureEngland);

        health.Max = health.Start + health.PerLevel * level;
        health.Current = health.Max;
        mana.Max = mana.Start + mana.PerLevel * level;
        mana.Current = 0;

        OnHealthChanged?.Invoke(this.health);
        OnManaChanged?.Invoke(this.mana);
        OnLevelChanged?.Invoke(this.level);
    }

    protected virtual void UpdateStat()
    {
        health.Max = health.Start + health.PerLevel * level;
        mana.Max = mana.Start + mana.PerLevel * level;

        moveSpeed.Current = moveSpeed.Start + moveSpeed.PerLevel * level + moveSpeed.Temporary;
        thrustForce.Current = thrustForce.Start + thrustForce.PerLevel * level + thrustForce.Temporary;
        resistance.Current = resistance.Start + resistance.PerLevel * level + resistance.Temporary;

        if (health.Current == 0)
        {
            DieHandle();
        }
    }

    public void CreateThrustTo(Ball target)
    {
        float realThrustForce = ThrustForce.GetRealThrustForce(this.thrustForce.Current, target.resistance.Current);
        target.GetComponent<Rigidbody>().AddForce(realThrustForce * GetDirectionToTarget(target.gameObject));
    }

    public void DealDamage(Ball target)
    {
        float damage = ThrustForce.GetRealThrustForce(this.thrustForce.Current, target.resistance.Current);
        target.health.Current -= damage;

        target.OnHealthChanged(target.health);
    }

    public void IncreaseMana(float manaIncrease)
    {
        this.mana.Current += manaIncrease;
        this.OnManaChanged(this.mana);
    }

    public void IncreaseHealth(float percentHealing)
    {
        this.health.Current += this.health.Max * percentHealing;
        this.OnHealthChanged(this.health);
    }

    public IEnumerator IncreaseThrustForceTemp(float factorThrustForce, float effectDuration)
    {
        float thrustForceIncrease = this.thrustForce.Start * (factorThrustForce - 1);

        this.thrustForce.Temporary += thrustForceIncrease;

        yield return new WaitForSeconds(effectDuration);

        this.thrustForce.Temporary -= thrustForceIncrease;
    }

    public IEnumerator IncreaseResistanceTemp(float resistanceBuff, float effectDuration)
    {
        this.resistance.Temporary += resistanceBuff;

        yield return new WaitForSeconds(effectDuration);

        this.resistance.Temporary -= resistanceBuff;
    }

    protected virtual void DetectOutBound()
    {
        if (IsOutBond())
        {
            DieHandle();
        }
    }

    protected bool IsOutBond()
    {
        bool isOutBound = Mathf.Abs(this.transform.position.x) > positionBound || Mathf.Abs(this.transform.position.y) > positionBound || Mathf.Abs(this.transform.position.z) > positionBound;

        return isOutBound;
    }

    public virtual void DieHandle()
    {
        this.gameObject.SetActive(false);
    }

    public Vector3 GetDirectionToTarget(GameObject target, bool isNormalized = false)
    {
        Vector3 positionTarget = target.transform.position;
        Vector3 positionMyself = this.transform.position;

        Vector3 directionToTarget = positionTarget - positionMyself;

        if (isNormalized)
        {
            return directionToTarget.normalized;
        }
        else
        {
            return directionToTarget;
        }
    }

    public void MoveTo(GameObject target, bool isNormalizedVelocity)
    {
        rigidbody.AddForce(GetDirectionToTarget(target, isNormalizedVelocity) * this.moveSpeed.Current);
    }

    public void RushTo(GameObject target, float speedFactor)
    {
        isNormalizedVelocity = true;
        rigidbody.AddForce(GetDirectionToTarget(target, isNormalizedVelocity) * this.moveSpeed.Current * speedFactor);

        status = StatusBall.Rush;
    }

    public bool IsTarget(GameObject ball)
    {
        return ball.CompareTag(tagTarget) ? true : false;
    }

    public void TemporarilyDontMove()
    {
        rigidbody.isKinematic = true;
        rigidbody.isKinematic = false;

        rigidbody.AddTorque(Vector3.up * 15);
    }

    public void LevelUp()
    {
        level++;
        OnLevelChanged(level);
    }

    public void SetLevel(int levelSet)
    {
        level = levelSet;
        OnLevelChanged(level);
    }

    public void EffectDurationCooldown(float effectDuration)
    {
        OnEffectDurationCooldown(effectDuration);
    }

    public bool IsOnGround()
    {
        if (transform.position.y > -1f)
        {
            return true;
        }

        return false;
    }
}
