using UnityEngine;
using TMPro;

public class CollisionHandler : MonoBehaviour {

    public TextMeshProUGUI scoreUI;
    public ChangeColorOnClick playerColorRef;

    private GameManager gameManager;


    private void Start() {
        gameManager = GameManager.instance;

        if (gameManager == null) {
            Debug.LogError("GameManager is not found. Make sure it is in the scene.");
        }

        scoreUI.text = "Score:0";
        playerColorRef = GetComponent<ChangeColorOnClick>();
    }

    // Called when a 2D collider enters another collider
    private void OnCollisionEnter2D(Collision2D collision) {
        
        // Check if the collision is with a circle
        if (collision.gameObject.CompareTag("RedCircle") || collision.gameObject.CompareTag("BlueCircle")) {
            // Get the color of the player's sprite
            Color playerColor = GetComponent<SpriteRenderer>().color;

            // Check if the circle has the same color as the player
            if (collision.gameObject.CompareTag("RedCircle") && playerColor == playerColorRef.color1) {
                // Increase the score
                gameManager.IncreaseScore(1);
                
                
            } else if (collision.gameObject.CompareTag("BlueCircle") && playerColor == playerColorRef.color2) {
                // Increase the score
                gameManager.IncreaseScore(1);
                
                
            } else if (collision.gameObject.CompareTag("RedCircle") && playerColor == playerColorRef.color2) {
                // gameover
                gameManager.GameOver();
            } else if (collision.gameObject.CompareTag("BlueCircle") && playerColor == playerColorRef.color1) {
                // gameover
                gameManager.GameOver();
            }
        }

        // Check if the collision is with a square
        else if (collision.gameObject.CompareTag("RedSquare") || collision.gameObject.CompareTag("BlueSquare")) {
            // Get the color of the player's sprite
            Color playerColor = GetComponent<SpriteRenderer>().color;

            // Check if the square has the opposite color as the player
            if (collision.gameObject.CompareTag("RedSquare") && playerColor == playerColorRef.color2) {
                // Increase the score
                gameManager.IncreaseScore(1);


            } else if (collision.gameObject.CompareTag("BlueSquare") && playerColor == playerColorRef.color1) {
                // Increase the score
                gameManager.IncreaseScore(1);
                
            } else if (collision.gameObject.CompareTag("BlueSquare") && playerColor == playerColorRef.color2) {
                // gameover
                gameManager.GameOver();
            } else if (collision.gameObject.CompareTag("RedSquare") && playerColor == playerColorRef.color1) {
                // gameover
                gameManager.GameOver();
            }
        }
    }
}
