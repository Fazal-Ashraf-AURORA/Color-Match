using UnityEngine;

public class ShapeController : MonoBehaviour
{
   // [SerializeField] GameObject shapePrefab;
    [SerializeField] float fallSpeed = 5.0f;

    //private void Awake() {
    //    shapePrefab = GetComponent<GameObject>();
    //}

    private void Update() {
        // Calculate the new position based on the fall speed
        Vector3 newPosition = transform.position + Vector3.down * fallSpeed * Time.deltaTime;

        // Update the position of the sprite
        transform.position = newPosition;
    }

    // Called when a 2D collider enters another collider
    private void OnCollisionEnter2D(Collision2D collision) {
        // Check if the collision is with the player (you may need to adjust the tag or layer)
        if (collision.gameObject.CompareTag("Player")) {
            // Destroy the GameObject when it collides with the player
            Destroy(gameObject);
        }
    }
}
