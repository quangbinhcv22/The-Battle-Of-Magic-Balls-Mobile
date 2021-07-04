using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenHealthBehavior : AbilityBehaviors
{
    new public const string name = "Regen Health";
    new public const string description = "Regen health base on percent max health";

    private float percentHealing;


    public RegenHealthBehavior(float percentHealing) : base(name, description)
    {
        this.percentHealing = percentHealing;
    }

    public override void PerformBehaviors(GameObject self, GameObject target)
    {
        Ball selfBall = self.GetComponent<Ball>();
        selfBall.IncreaseHealth(percentHealing);
    }
}
