using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted;

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
    }

    public void GameOver()
    {

    }
}
