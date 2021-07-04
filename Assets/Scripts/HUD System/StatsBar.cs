using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class StatsBar : MonoBehaviour
{
    public Image healthBar;
    public Image manaBar;
    public Image effectDurationBar;
    public Image effectDurationBackground;
    public Text levelText;


    private Ball targetBallFolow;
    private Vector3 distanceToTarget;
    private Quaternion startRotate;

    private Stopwatch effectDurationTimer = new Stopwatch();

    private void OnEnable()
    {
        targetBallFolow = GetComponentInParent<Ball>();

        targetBallFolow.OnHealthChanged += WhenHealthChanged;
        targetBallFolow.OnManaChanged += WhenManaChanged;
        targetBallFolow.OnLevelChanged += WhenLevelChanged;
        targetBallFolow.OnEffectDurationCooldown += WhenEffectDurationCooldown;
    }

    void Start()
    {
        distanceToTarget = this.transform.position - targetBallFolow.transform.position;
        startRotate = transform.rotation;

        if (effectDurationBar != null)
        {
            effectDurationBar.gameObject.SetActive(false);
            effectDurationBackground.gameObject.SetActive(false);
        }
    }

    void LateUpdate()
    {
        FlowTarget();
        DontRotate();
    }

    void WhenHealthChanged(Health health)
    {
        float currentHealthPercentage = health.Current / health.Max;
        healthBar.fillAmount = currentHealthPercentage;
    }

    void WhenManaChanged(Mana mana)
    {
        float currentManaPercentage = mana.Current / mana.Max;
        manaBar.fillAmount = currentManaPercentage;
    }

    void WhenLevelChanged(int level)
    {
        levelText.text = level.ToString();
    }

    void WhenEffectDurationCooldown(float effectDuration)
    {
        StartCoroutine(EffectDurationCooldown(effectDuration));
    }

    void FlowTarget()
    {
        transform.position = targetBallFolow.transform.position + distanceToTarget;
    }

    void DontRotate()
    {
        transform.rotation = startRotate;
    }

    IEnumerator EffectDurationCooldown(float effectDuration)
    {
        effectDurationBar.gameObject.SetActive(true);
        effectDurationBackground.gameObject.SetActive(true);

        effectDurationTimer.Start();

        while (effectDurationTimer.IsRunning && effectDurationTimer.Elapsed.TotalSeconds < effectDuration)
        {
            effectDurationBar.fillAmount = (float)(1 - effectDurationTimer.Elapsed.TotalSeconds / effectDuration);
            yield return null;
        }

        effectDurationBar.gameObject.SetActive(false);
        effectDurationBackground.gameObject.SetActive(false);

        effectDurationTimer.Stop();
        effectDurationTimer.Reset();

        yield return null;
    }
}
