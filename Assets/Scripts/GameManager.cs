using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI finalScoreUI;
    public static  bool isGameOver = false;
    public static int SCORE = 0;
    [SerializeField] CollisionHandler collisionHandler;
    //[SerializeField] ShapeController[] shapeController;
    [SerializeField]private float currentSpeed; // The current speed of the game.

    [SerializeField] GameObject gameOverUI;

    public float baseSpeed = 1.0f; // The base speed of the game.
    private int previousScore = 0; // The score from the previous frame.

    void Start() {
        isGameOver = false;
        gameOverUI.SetActive(false);
        SCORE = 0;
      
        Application.targetFrameRate = 60;
        
        // Initialize the current speed to the base speed.
        currentSpeed = baseSpeed;
    }

    void Update() {

        // Get the current score from your score manager.
        int currentScore = SCORE;

        // Check if the score has increased by 10 or more since the last frame.
        if (currentScore >= previousScore + 5) {
            // Increase the speed by a certain factor. You can adjust this to your liking.
            currentSpeed += 1.1f;

            Time.timeScale = currentSpeed;

            // Update the previous score.
            previousScore = currentScore;
        }

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
