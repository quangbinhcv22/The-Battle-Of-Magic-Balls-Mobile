using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public string contentScore = "Score: ";
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        UpdateScoretext();
    }

    void UpdateScoretext()
    {
        scoreText.text = "Score: " + GameManager.Instance.score.ToString();
    }
}
