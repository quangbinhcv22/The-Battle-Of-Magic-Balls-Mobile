using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffResistanceTempBehavior : AbilityBehaviors
{
    new public const string name = "Buff Thrust Force Temp";
    new public const string description = "Buff thrust force in a time";

    private float resistanceBuff;
    private float effectDuration;

    public BuffResistanceTempBehavior(float resistanceBuff, float effectDuration) : base(name, description)
    {
        this.resistanceBuff = resistanceBuff;
        this.effectDuration = effectDuration;
    }

    public override void PerformBehaviors(GameObject self, GameObject target)
    {
        Ball selfBall = self.GetComponent<Ball>();
        selfBall.StartCoroutine(selfBall.IncreaseResistanceTemp(resistanceBuff, effectDuration));
    }
}
