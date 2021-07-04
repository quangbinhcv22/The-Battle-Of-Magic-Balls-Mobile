using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        PlayBattle();
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
    }

    public void PlayBattle()
    {
        ResetScore();
    }
}
