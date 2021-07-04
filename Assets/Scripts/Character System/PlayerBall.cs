using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : Ball
{

    public delegate void BallCollisionWithTargetHandler(Vector3 collisionPoint);
    public delegate void GameOverHandle();

    public event BallCollisionWithTargetHandler OnPlayerCollisionWithTarget;
    public event GameOverHandle OnGameOver;

    public override void OnCollisionEnter(Collision collision)
    {

        if (IsTarget(collision.gameObject))
        {
            Vector3 collisionPoint = collision.GetContact(0).point;

            OnPlayerCollisionWithTarget(collisionPoint);
        }

        base.OnCollisionEnter(collision);

    }


    public override void DieHandle()
    {
        OnGameOver();
        gameObject.SetActive(false);
    }
}
