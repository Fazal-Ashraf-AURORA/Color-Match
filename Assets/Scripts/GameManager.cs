using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] CollisionHandler collisionHandler;
    [SerializeField] ShapeController[] shapeController;
    //[SerializeField] ShapeGenerator shapeGenerator;



    public float baseSpeed = 1.0f; // The base speed of the game.
    [SerializeField]private float currentSpeed; // The current speed of the game.
    private int previousScore = 0; // The score from the previous frame.

    void Start() {
        Application.targetFrameRate = 60;
        // Initialize the current speed to the base speed.
        currentSpeed = baseSpeed;
    }

    void Update() {
        // Get the current score from your score manager.
        int currentScore = collisionHandler.score;

        // Check if the score has increased by 10 or more since the last frame.
        if (currentScore >= previousScore + 5) {
            // Increase the speed by a certain factor. You can adjust this to your liking.
            currentSpeed *= 1.1f;

            Time.timeScale = currentSpeed;

            // Update the previous score.
            previousScore = currentScore;
        }

        foreach (ShapeController shapeController in shapeController) { }
    }
}
