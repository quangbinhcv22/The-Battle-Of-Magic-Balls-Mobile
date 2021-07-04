using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushToEnemyAbilityUse : AbilityUse
{
    private void Start()
    {
        ability = new RushToEnemyAbility();
    }

    new public void OnAbilityUse()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");

        base.OnAbilityUse();
    }


}
