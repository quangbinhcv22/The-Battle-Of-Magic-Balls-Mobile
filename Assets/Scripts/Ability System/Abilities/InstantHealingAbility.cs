using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantHealingAbility : Ability
{
    new public const string name = "Instant Healing";
    new public const string description = "Regen health base on percent max health";

    new public const float manaCost = 0f;
    new public const float cooldown = 8f;
    new public const float castTime = 0f;

    private const float percentHealing = 0.2f;



    public InstantHealingAbility() : base(name, description, manaCost, cooldown, castTime)
    {
        behaviors.Add(new RegenHealthBehavior(percentHealing));
    }
}
