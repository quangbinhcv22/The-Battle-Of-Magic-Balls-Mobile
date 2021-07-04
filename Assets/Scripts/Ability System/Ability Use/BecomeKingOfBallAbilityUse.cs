using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeKingOfBallAbilityUse : AbilityUse
{
    private void Start()
    {
        ability = new BecomeKingOfBallAbility();
        target = null;
    }
}
