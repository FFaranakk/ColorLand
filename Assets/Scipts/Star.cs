using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject rectangleObject; // Reference to the rectangle object
    private SpriteRenderer rectangleSpriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component of the rectangle object
        if (rectangleObject != null)
        {
            rectangleSpriteRenderer = rectangleObject.GetComponent<SpriteRenderer>();

            // Initially set the rectangle to be fully visible (optional)
            SetRectangleOpacity(0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with the star
        if (other.gameObject.CompareTag("Player"))
        {
            // Deactivate the rectangle GameObject
            if (rectangleObject != null)
            {
                rectangleObject.SetActive(false);
            }

            // Make the star disappear
            gameObject.SetActive(false);
        }
    }

    private void SetRectangleOpacity(float alpha)
    {
        if (rectangleSpriteRenderer != null)
        {
            Color color = rectangleSpriteRenderer.color;
            color.a = alpha; // Set the alpha value
            rectangleSpriteRenderer.color = color;
        }
    }
}