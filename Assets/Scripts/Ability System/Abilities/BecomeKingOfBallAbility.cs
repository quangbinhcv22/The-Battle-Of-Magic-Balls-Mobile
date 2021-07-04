using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeKingOfBallAbility : Ability
{
    new public const string name = "Become King of Ball";
    new public const string description = "Power up self's resistance and thrust force";

    new public const float manaCost = 0f;
    new public const float cooldown = 30f;
    new public const float castTime = 0f;

    private const float factorThrustForce = 10;
    private const float resistanceBuff = 1.0f;
    new private const float effectDuration = 5.0f;


    public BecomeKingOfBallAbility() : base(name, description, manaCost, cooldown, castTime, effectDuration)
    {
        behaviors.Add(new BuffThrustForceTempBehavior(factorThrustForce, effectDuration));
        behaviors.Add(new BuffResistanceTempBehavior(resistanceBuff, effectDuration));
    }
}
