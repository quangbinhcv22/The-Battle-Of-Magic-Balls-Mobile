using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushToEnemyAbility : Ability
{
    new public const string name = "Rush to Enemy";
    new public const string description = "Teleport yourself to a safe place";

    new public const float manaCost = 0f;
    new public const float cooldown = 1f;
    new public const float castTime = 0f;

    private float rushSpeed = 100;


    public RushToEnemyAbility() : base(name, description, manaCost, cooldown, castTime)
    {
        behaviors.Add(new RushToTargetBehavior(rushSpeed));
    }
}
