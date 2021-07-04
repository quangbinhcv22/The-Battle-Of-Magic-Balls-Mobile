using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushToTargetBehavior : AbilityBehaviors
{
    new public const string name = " Teleport to Position";
    new public const string description = "Teleport yourself to point in area";

    private float rushSpeed;


    public RushToTargetBehavior(float rushSpeed) : base(name, description)
    {
        this.rushSpeed = rushSpeed;
    }

    public override void PerformBehaviors(GameObject self, GameObject target)
    {
        self.GetComponent<Ball>().RushTo(target, rushSpeed);
    }


}
