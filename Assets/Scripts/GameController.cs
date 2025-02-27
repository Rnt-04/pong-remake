using UnityEngine;
using TMPro; // For TextMesh Pro

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText; // Player score TextMeshPro
    public TextMeshProUGUI cpuScoreText;    // CPU score TextMeshPro
    private int playerScore = 0;
    private int cpuScore = 0;

    void Start()
    {
        UpdateScoreUI();
    }

    public void UpdateScore(string scorer)
    {
        if (scorer == "Player")
        {
            playerScore++;
        }
        else if (scorer == "CPU")
        {
            cpuScore++;
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        playerScoreText.text = "Player: " + playerScore;
        cpuScoreText.text = "CPU: " + cpuScore;
    }

    public void ResetScore()
    {
        playerScore = 0;
        cpuScore = 0;
        UpdateScoreUI();
    }
}
