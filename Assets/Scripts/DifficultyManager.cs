using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static float ballSpeed = 5f; // Default ball speed (Easy)
    public static float cpuPaddleSpeed = 25f; // Default paddle speed (Easy)
    public static float cpuReactionTime = 0.2f; // Default reaction time (Easy)

    public void SetDifficulty(int difficultyIndex)
    {
        switch (difficultyIndex)
        {
            case 0: // Easy
                ballSpeed = 6f;
                cpuPaddleSpeed = 45f;
                cpuReactionTime = 0.4f;
                break;
            case 1: // Normal
                ballSpeed = 7f;
                cpuPaddleSpeed = 60f;
                cpuReactionTime = 0.2f;
                break;
            case 2: // Hard
                ballSpeed = 10f;
                cpuPaddleSpeed = 120f;
                cpuReactionTime = 0.1f; // Instant reaction on Hard
                break;
        }

        Debug.Log($"Difficulty set to: {difficultyIndex} | Ball Speed: {ballSpeed} | CPU Paddle Speed: {cpuPaddleSpeed} | CPU Reaction Time: {cpuReactionTime}");
    }
}
