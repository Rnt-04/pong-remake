using UnityEngine;

public class CPUPaddle : MonoBehaviour
{
    public Transform ball; // Reference to the ball
    private float speed; // Speed of the paddle
    private float reactionTime; // Delay to mimic human reaction

    private float targetY;

    void Start()
    {
        // Set paddle speed and reaction time based on the difficulty
        speed = DifficultyManager.cpuPaddleSpeed;
        reactionTime = DifficultyManager.cpuReactionTime;
    }

    void Update()
    {
        // Smoothly follow the ball's Y position with some delay based on reaction time
        targetY = Mathf.Lerp(transform.position.y, ball.position.y, reactionTime);

        // Ensure the paddle moves at the appropriate speed, even when it has no reaction time (Hard mode)
        float movement = Mathf.Clamp(targetY - transform.position.y, -1, 1) * speed * Time.deltaTime;

        // Move the CPU paddle
        transform.Translate(0, movement, 0);

        // Restrict movement within the screen bounds
        float clampedY = Mathf.Clamp(transform.position.y, -3.5f, 3.5f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
