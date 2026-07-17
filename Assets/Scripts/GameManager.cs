using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted;

    public GameObject platformSpawner;
    public GameObject gamePlayUI;
    public GameObject menuUI;
    int score = 0;
    int highScore = 0;
    int diamondScore = 0;

    public TMP_Text highScoreText;
    public TMP_Text scoreText;

    public TMP_Text diamondScoreText;

    private Coroutine scoreCoroutine;

    AudioSource audioSource;

    public AudioClip[] gameMusic;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");

        highScoreText.text = "High Score: " + highScore.ToString();

        diamondScoreText.text = "Diamond: " + diamondScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartGame();
            }
        }
    }
    

    public void StartGame()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
        gamePlayUI.SetActive(true);
        menuUI.SetActive(false);
        audioSource.clip = gameMusic[1];
        audioSource.Play();

        scoreCoroutine = StartCoroutine(UpdateScore());

    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine(scoreCoroutine);
        SaveHighScore();
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            
            scoreText.text = score.ToString();
        }
    }

    void SaveHighScore()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void AddDiamond(int amount)
    {
        diamondScore += amount;
        diamondScoreText.text = "Diamond: " +diamondScore.ToString();
        Debug.Log("Diamond: " + diamondScore);
    }
}
