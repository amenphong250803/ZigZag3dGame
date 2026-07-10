using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted;

    public GameObject platformSpawner;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);

        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
