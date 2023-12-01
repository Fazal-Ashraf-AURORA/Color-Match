using UnityEngine;

public class ChangeColorOnClick : MonoBehaviour {
    public Color color1; // First color
    public Color color2; // Second color

    private SpriteRenderer spriteRenderer;
    private bool isColor1 = true; // Flag to toggle between colors

    void Start() {
        // Get the SpriteRenderer component attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.color = color1;

        // Ensure the SpriteRenderer component is present
        if (spriteRenderer == null) {
            Debug.LogError("SpriteRenderer component not found on GameObject.");
        }
    }

    void OnMouseDown() {
        // Toggle between colors when the sprite is clicked
        if (isColor1) {
            spriteRenderer.color = color2;
        } else {
            spriteRenderer.color = color1;
        }

        // Update the flag for the next click
        isColor1 = !isColor1;
    }
}
