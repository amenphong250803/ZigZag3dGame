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

    int totalDiamond = 0;
    int currentDiamond = 0;

    public TMP_Text highScoreText;
    public TMP_Text scoreText;

    public TMP_Text totalDiamondText;
    public TMP_Text currentDiamondText;

    private Coroutine scoreCoroutine;

    private bool gameOver = false;

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
        totalDiamond = PlayerPrefs.GetInt("Diamond");

        highScoreText.text = "High Score: " + highScore.ToString();
        totalDiamondText.text = "Diamond: " + totalDiamond.ToString();
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
        if (gameOver == true)
        {
            return;
        }

        gameOver = true;

        platformSpawner.SetActive(false);
        StopCoroutine(scoreCoroutine);

        totalDiamond += currentDiamond;

        PlayerPrefs.SetInt("Diamond", totalDiamond);
        PlayerPrefs.Save();

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

    public void AddDiamond()
    {   
        audioSource.PlayOneShot(gameMusic[2]);
        currentDiamond += 1;
        currentDiamondText.text = currentDiamond.ToString();
    }


}
