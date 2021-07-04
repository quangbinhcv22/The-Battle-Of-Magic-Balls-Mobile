using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public string name;
    public string description;

    public float manaCost;
    public float cooldown;
    public float castTime;
    public float effectDuration;

    public List<AbilityBehaviors> behaviors;


    public Ability()
    {
        this.name = "Default name";
        this.description = "Default description";

        this.manaCost = 0f;
        this.cooldown = 0f;
        this.castTime = 0f;

        behaviors = new List<AbilityBehaviors>();
    }

    public Ability(string name, string description, float manaCost, float cooldown, float castTime)
    {
        this.name = name;
        this.description = description;

        this.manaCost = manaCost;
        this.cooldown = cooldown;
        this.castTime = castTime;
        this.effectDuration = 0;

        behaviors = new List<AbilityBehaviors>();
    }

    public Ability(string name, string description, float manaCost, float cooldown, float castTime, float effectDuration)
    {
        this.name = name;
        this.description = description;

        this.manaCost = manaCost;
        this.cooldown = cooldown;
        this.castTime = castTime;
        this.effectDuration = effectDuration;

        behaviors = new List<AbilityBehaviors>();
    }


    public void UseAbility(GameObject self, GameObject target = null)
    {
        foreach (AbilityBehaviors behavior in behaviors)
        {
            behavior.PerformBehaviors(self, target);
        }
    }
}
