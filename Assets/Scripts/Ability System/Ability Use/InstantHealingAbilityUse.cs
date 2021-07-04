using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantHealingAbilityUse : AbilityUse
{
    private void Start()
    {
        ability = new InstantHealingAbility();
        target = null;
    }
}
