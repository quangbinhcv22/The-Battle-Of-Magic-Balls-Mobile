using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Instance.PlayBattle();
        SceneManager.LoadScene("Battle");
    }

    public void GameOver()
    {
        GameManager.Instance.PlayBattle();
        SceneManager.LoadScene("");
    }
}
