using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : Ball
{
    public delegate void EnemyBallDieHandler();
    public event EnemyBallDieHandler OnEnemyDie;

    private GameObject player;

    private EffectBattle effectBattle;
    private SpawnManager spawnManager;

    private void Awake()
    {
        effectBattle = FindObjectOfType<EffectBattle>();
        spawnManager = FindObjectOfType<SpawnManager>();

        OnEnemyDie += effectBattle.WhenEnemyDie;
        OnEnemyDie += spawnManager.SpawnNewEnemyWaveIfNoEnemy;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (IsOnGround())
        {
            MoveToPlayer();
        }
    }

    public override void DieHandle()
    {
        GameManager.Instance.AddScore(ScoreWhenDie);
        gameObject.SetActive(false);

        transform.position = new Vector3(0, 0, 0);
        TemporarilyDontMove();

        OnEnemyDie();
    }

    protected void MoveToPlayer()
    {
        rigidbody.AddForce(GetDirectionToTarget(player, isNormalizedVelocity) * moveSpeed.Current);
    }
}
