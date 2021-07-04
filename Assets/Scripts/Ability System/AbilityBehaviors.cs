using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviors
{
    public string name;
    public string description;


    public AbilityBehaviors(string name, string description)
    {
        this.name = name;
        this.description = description;
    }


    public virtual void PerformBehaviors(GameObject self, GameObject target)
    {
        Debug.LogWarning("Need to add behavior!");
    }
}
