using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageTextEffect : MonoBehaviour
{
    public float lifeTime = 1.0f;

    private void OnEnable()
    {
        Invoke("SetActiveFalseWhenDoneAnimation", lifeTime);
    }

    void SetActiveFalseWhenDoneAnimation()
    {
        gameObject.SetActive(false);
    }
}
