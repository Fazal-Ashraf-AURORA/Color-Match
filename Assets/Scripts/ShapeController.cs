using UnityEngine;

public class ShapeController : MonoBehaviour {
    private float fallSpeed = 5.0f;

    private void Update() {
        Vector3 newPosition = transform.position + Vector3.down * fallSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
