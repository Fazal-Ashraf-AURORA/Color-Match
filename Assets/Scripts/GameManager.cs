using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public TextMeshProUGUI finalScoreUI;
    public static  bool isGameOver = false;
    public static int SCORE = 0;
    [SerializeField] CollisionHandler collisionHandler;

    [SerializeField] GameObject gameOverUI;
    private int previousScore = 0; // The score from the previous frame.

    void Start() {
        isGameOver = false;
        gameOverUI.SetActive(false);
        SCORE = 0;
      
        Application.targetFrameRate = 60;
        
    }

    void Update() {

        // Get the current score from your score manager.
        int currentScore = SCORE;

        if(isGameOver) {
            GameOver();
        }
    }

    public void PauseGame() {
        Time.timeScale = 0; // Pause the game
    }

    public void ResumeGame() {
        Time.timeScale = 1; // Resume the game
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay");
        isGameOver = false;
    }

    public void GotoMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Mainmenu");
    }

    public void GameOver() {
        Debug.Log("Game Over!!!");
        isGameOver = false;

        finalScoreUI.text = "Score: "+SCORE;

        isGameOver = false;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
}
