using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSafePlaceAbility : Ability
{
    new public const string name = "Go to Safe Place";
    new public const string description = "Rush to the enemy with a faster speed";

    new public const float manaCost = 0f;
    new public const float cooldown = 3.5f;
    new public const float castTime = 0f;

    private Vector3 positionTeleport = new Vector3(0f, 3f, 0f);
    private float rangeTeleport = 3.0f;


    public GoToSafePlaceAbility() : base(name, description, manaCost, cooldown, castTime)
    {
        behaviors.Add(new TeleportToPositionBehavior(positionTeleport, rangeTeleport));
    }
}
