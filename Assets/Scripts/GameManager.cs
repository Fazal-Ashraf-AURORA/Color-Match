using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager instance;//singleton instance

    public GameObject gameScreen;
    public GameObject gameOverScreen;
    public GameObject pauseMenu;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;//Game Over score

    public ShapeGenerator shapeGenerator;

    public static int score = 0;
    [SerializeField]int gameOverCount = 0;//counter for game overs
    public  bool isGameActive = true;
    public bool isPaused = false;

    public string[] objectNamesToDestroy; // Array of GameObject names to destroy

    #region Advertisement

    loadBanner banner;
    loadInterstitial interstitial;
    loadRewarded rewarded;

    #endregion

    private void Awake() {
        if (instance == null) {
            // If no instance exists, set the current instance to this and mark it to not be destroyed on load
            instance = this;
        } else {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
        banner = FindObjectOfType<loadBanner>();
        interstitial = FindObjectOfType<loadInterstitial>();
    } 

    void Start() {
        // Get a reference to the ShapeGenerator script
        shapeGenerator = FindObjectOfType<ShapeGenerator>();

        if (shapeGenerator == null) {
            Debug.LogError("ShapeGenerator script not found. Make sure it is in the scene.");
        }

        ShowStartScreen();
        banner.LoadBanner();
        interstitial.LoadAd();

        Application.targetFrameRate = 60;
        
    }
    void Update() {
        //checking if the interstitial ad is loaded
        if(loadInterstitial.adLoaded) {
            return;
        } else {
        interstitial.LoadAd();
        }
    }

    void DestroyGameObjectsByNames(string[] names) {
        // Loop through the array of names
        foreach (string name in names) {
            // Find the GameObject by name in the scene
            GameObject objectToDestroy = GameObject.Find(name);

            // Check if the GameObject was found
            if (objectToDestroy != null) {
                // Destroy the GameObject
                Destroy(objectToDestroy);
            } else {
                // Print a message if the GameObject was not found
                //Debug.LogWarning("GameObject with name '" + name + "' not found.");
            }
        }
    }

    public void GameOver() {
        isGameActive = false;
        HideGameScreen();
        
        finalScoreText.text = scoreText.text;
        ShowGameOverScreen();

        gameOverCount++;

        //show interstitial ad after every 2 game overs
        if(gameOverCount > 2) {
            interstitial.ShowAd();// show interstitial ad when the game starts
            gameOverCount = 0;//Reset the counter
        }

        // Stop spawning when the game is over
        shapeGenerator.StopSpawning();
    }

    public void IncreaseScore(int points) {
        score += points;
        UpdateScoreText();
    }
    private void ResetGame() {
        // Call the function to find and destroy GameObjects by names
        DestroyGameObjectsByNames(objectNamesToDestroy);
        score = 0;
        UpdateScoreText();
        shapeGenerator.StartSpawning();
    }

    private void UpdateScoreText() {
        scoreText.text = "Score: " + score;
    }
    private void ShowStartScreen() {
        gameScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }
    private void HideGameScreen() {
        gameScreen.SetActive(false);
    }

    private void ShowGameOverScreen() {
        gameOverScreen.SetActive(true );
    }

    public void PauseGame() {
        Time.timeScale = 0; // Pause the game
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1; // Resume the game
        pauseMenu.SetActive(false );
    }

    public void RestartGame() {
        
        ResetGame();
        gameOverScreen.SetActive(false );
        pauseMenu.SetActive(false );
        gameScreen.SetActive(true);
        Time.timeScale = 1; // Resume the game
    }

    public void GotoMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Mainmenu");
    }


}
