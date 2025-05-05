using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float Move;
    public float jump;
    public bool ColorIsObtained;
    public bool isjumping;
    public bool useSpriteRendererFlip = true; // Choose flip method
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector3 startPoint; // Store the player's starting position

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.freezeRotation = true;

        // Save the player's starting position
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Move < -0.1f) // Moving left
        {
            if (useSpriteRendererFlip && spriteRenderer != null)
                spriteRenderer.flipX = true;
            else
                transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (Move > 0.1f) // Moving right
        {
            if (useSpriteRendererFlip && spriteRenderer != null)
                spriteRenderer.flipX = false;
            else
                transform.localScale = Vector3.one;
        }

        if (Input.GetButtonDown("Jump") && !isjumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            Debug.Log("UP");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isjumping = false;
            Debug.Log("On the ground");
        }
        else if (other.gameObject.tag == "Finish") // Check for "finish" tag
{
    Debug.Log("Player reached the finish line in: " + SceneManager.GetActiveScene().name);

    // Determine the current scene and load the next one
    string currentScene = SceneManager.GetActiveScene().name;

    if (currentScene == "Level1")
    {
        SceneManager.LoadScene("Level2"); // Load Level 2
    }
    else if (currentScene == "Level2")
    {
        SceneManager.LoadScene("Level3"); // Load Level 3
    }
    else if (currentScene == "Level3")
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOver"); // Load Game Over screen
    }
}
        else if (other.gameObject.tag == "fall") // Check for "fall" tag
        {
            Debug.Log("Player fell! Returning to start point.");
            transform.position = startPoint; // Reset player position to the starting point
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isjumping = true;
            Debug.Log("air");
        }
    }
}