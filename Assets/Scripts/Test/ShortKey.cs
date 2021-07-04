using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortKey : MonoBehaviour
{
    public KeyCode key;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key) && button.IsInteractable())
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
