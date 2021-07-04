using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSafePlaceAbilityUse : AbilityUse
{
    private void Start()
    {
        ability = new GoToSafePlaceAbility();
        target = null;
    }
}
