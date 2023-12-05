using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    #region Advertisement

    loadBanner banner;
    loadInterstitial interstitial;
    loadRewarded rewarded;
    int gameOverCounts = 0;

    #endregion

    [SerializeField] Canvas canvas;
    [SerializeField] CollisionHandler collisionHandler;
    [SerializeField] GameObject gameOverUI;
    public TextMeshProUGUI finalScoreUI;

    public static bool isGameOver = false;
    public static int SCORE = 0;

    private int previousScore = 0; // The score from the previous frame.

    private void Awake() {
        //if (instance == null) {
        //    // If no instance exists, set the current instance to this and mark it to not be destroyed on load
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //} else {
        //    // If an instance already exists, destroy this one
        //    Destroy(gameObject);
        //}

        canvas = FindAnyObjectByType<Canvas>();

        banner = canvas.GetComponent<loadBanner>();
        interstitial = canvas.GetComponent<loadInterstitial>();
        rewarded = canvas.GetComponent<loadRewarded>();
    }

    void Start() {
        isGameOver = false;
        gameOverUI.SetActive(false);
        SCORE = 0;

        Application.targetFrameRate = 60;
        banner.LoadBanner();
    }

    void Update() {
        // Get the current score from your score manager.
        int currentScore = SCORE;

        if (isGameOver) {
            Debug.Log(gameOverCounts);
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

        // Check if the script component is still attached to a GameObject
        if (this == null || gameObject == null) {
            return;
        }

        // Check if the GameManager's GameObject is not null before accessing it
        if (gameObject != null) {
            isGameOver = false;
            //gameOverCounts++;

            interstitial.LoadAd();

            finalScoreUI.text = "Score: " + SCORE;

            Time.timeScale = 0;
            gameOverUI.SetActive(true);

            
        }
    }

}
