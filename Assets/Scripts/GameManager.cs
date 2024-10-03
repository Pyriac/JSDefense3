using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver;
    public GameObject gameOverUI;

    void Start() {
        gameIsOver = false;
    }
    void Update()
    {
        if(gameIsOver)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
        
    }

    void EndGame()
    {
        gameIsOver = true;
       gameOverUI.SetActive(true);
       Time.timeScale = 0;
    }
}
