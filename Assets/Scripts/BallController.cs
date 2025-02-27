using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private AudioManager audioManager; // Reference to AudioManager
    private GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();  // Get the AudioManager
        gameController = FindObjectOfType<GameController>();  // Get the GameController
        speed = DifficultyManager.ballSpeed;
        LaunchBall();
    }

    void LaunchBall()
    {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        float yDirection = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CPU")||collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity *= 1.1f; // Increase speed on each paddle hit
            audioManager.PlayPaddleHitSound(); // Play paddle hit sound
        }
    }

    void Update()
    {
        // Check scoring boundaries
        if (transform.position.x < -9f) // Left boundary
        {
            gameController.UpdateScore("Player"); // Player scores
            audioManager.PlayScoreSound(); // Play score sound
            ResetBall();
        }
        else if (transform.position.x > 9f) // Right boundary
        {
            gameController.UpdateScore("CPU"); // CPU scores
            audioManager.PlayScoreSound(); // Play score sound
            ResetBall();
        }
    }

    void ResetBall()
    {
        transform.position = Vector3.zero; // Reset ball position
        rb.linearVelocity = Vector2.zero; // Stop ball movement
        LaunchBall(); // Launch ball again
    }
}