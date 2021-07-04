using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffThrustForceTempBehavior : AbilityBehaviors
{
    new public const string name = "Buff Thrust Force Temp";
    new public const string description = "Buff thrust force in a time";

    private float factorThrustForce;
    private float effectDuration;

    public BuffThrustForceTempBehavior(float factorThrustForce, float effectDuration) : base(name, description)
    {
        this.factorThrustForce = factorThrustForce;
        this.effectDuration = effectDuration;
    }

    public override void PerformBehaviors(GameObject self, GameObject target)
    {
        Ball selfBall = self.GetComponent<Ball>();
        selfBall.StartCoroutine(selfBall.IncreaseThrustForceTemp(factorThrustForce, effectDuration));
    }
}
