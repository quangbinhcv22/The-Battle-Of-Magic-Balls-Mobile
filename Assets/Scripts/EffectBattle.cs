using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class EffectBattle : MonoBehaviour
{
    public List<AudioClip> enemyCollisionSound;
    public AudioClip gameOverSound;
    public AudioClip enemyDieSound;

    public Image BackgroundGameOver;

    public ParticleSystem enemyCollisionParticle;

    private AudioSource audioSource;

    private Stopwatch effectTimer = new Stopwatch();


    // Start is called before the first frame update
    void Start()
    {
        PlayerBall player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBall>();
        player.OnPlayerCollisionWithTarget += WhenPlayerCollision;
        player.OnGameOver += WhenGameOver;

        audioSource = GetComponent<AudioSource>();
        BackgroundGameOver.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void WhenPlayerCollision(Vector3 collisionPoint)
    {
        if (audioSource.isPlaying == false)
        {
            int indexRandom = Random.Range(0, enemyCollisionSound.Count);
            audioSource.PlayOneShot(enemyCollisionSound[indexRandom]);
        }

        enemyCollisionParticle.transform.position = collisionPoint;
        enemyCollisionParticle.Play();
    }

    void WhenGameOver()
    {
        audioSource.PlayOneShot(gameOverSound);
        StartCoroutine(LoadSceneGameOver());
    }

    public void WhenEnemyDie()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(enemyDieSound);
        }
    }

    IEnumerator LoadSceneGameOver()
    {
        float timeBeforeLoadSceneGameOver = 3.5f;
        BackgroundGameOver.gameObject.SetActive(true);

        effectTimer.Start();

        while (effectTimer.IsRunning && effectTimer.Elapsed.TotalSeconds < timeBeforeLoadSceneGameOver)
        {
            Color colorBackgroundGameOver = new Color(0, 0, 0, Mathf.Sqrt((float)(effectTimer.Elapsed.TotalSeconds / timeBeforeLoadSceneGameOver)));
            BackgroundGameOver.color = colorBackgroundGameOver;

            yield return null;
        }

        SceneManager.LoadScene("GameOver");

        yield return null;
    }
}
