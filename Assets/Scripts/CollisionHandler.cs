using UnityEngine;
using TMPro;

public class CollisionHandler : MonoBehaviour {
    
    public int score = 0; // Player score
    public TextMeshProUGUI scoreUI;

    private void Start() {
        scoreUI.text = "Score:0";
    }

    // Called when a 2D collider enters another collider
    private void OnCollisionEnter2D(Collision2D collision) {
        // Check if the collision is with a circle
        if (collision.gameObject.CompareTag("RedCircle") || collision.gameObject.CompareTag("BlueCircle")) {
            // Get the color of the player's sprite
            Color playerColor = GetComponent<SpriteRenderer>().color;

            // Check if the circle has the same color as the player
            if (collision.gameObject.CompareTag("RedCircle") && playerColor == Color.red) {
                // Increase the score
                score++;
                scoreUI.text = "Score: " + score;
                //Debug.Log("Score: " + score);
            } else if (collision.gameObject.CompareTag("BlueCircle") && playerColor == Color.blue) {
                // Increase the score
                score++;
                scoreUI.text = "Score: " + score;
                //Debug.Log("Score: " + score);
            }
        }

        // Check if the collision is with a square
        else if (collision.gameObject.CompareTag("RedSquare") || collision.gameObject.CompareTag("BlueSquare")) {
            // Get the color of the player's sprite
            Color playerColor = GetComponent<SpriteRenderer>().color;

            // Check if the square has the opposite color as the player
            if (collision.gameObject.CompareTag("RedSquare") && playerColor == Color.blue) {
                // Increase the score
                score++;
                scoreUI.text = "Score: " + score;
                //Debug.Log("Score: " + score);
            } else if (collision.gameObject.CompareTag("BlueSquare") && playerColor == Color.red) {
                // Increase the score
                score++;
                scoreUI.text = "Score: " + score;
                //Debug.Log("Score: " + score);
            }
        }
    }
}
