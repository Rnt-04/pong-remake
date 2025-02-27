using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Background music for all scenes
    public AudioClip paddleHitSound;  // Paddle hit sound effect
    public AudioClip scoreSound;      // Scoring sound effect
    private AudioSource audioSource;  // AudioSource component

    private bool isGameScene = false; // Flag to track if we are in the game scene

    private static AudioManager instance; // Singleton instance

    void Awake()
    {
        // Implement the singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instance
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Ensure this object persists between scenes

        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the scene is the game scene or menu scene
        if (scene.name == "MainScene") // Replace with your actual game scene name
        {
            // If we are entering the game scene, stop the background music
            StopBackgroundMusic();
            isGameScene = true;
        }
        else if (scene.name == "MainMenu" || scene.name == "OptionsMenu") // Replace with your menu scene names
        {
            // If we are in the menu or options scene, resume the background music
            if (!audioSource.isPlaying)
            {
                PlayBackgroundMusic();
            }
            isGameScene = false;
        }
    }

    // Method to play background music (loops forever)
    public void PlayBackgroundMusic()
    {
        if (audioSource.isPlaying)
            return;

        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Loop the background music
        audioSource.Play();
    }

    // Method to stop the background music if needed
    public void StopBackgroundMusic()
    {
        audioSource.Stop();
    }

    // Play sound effects
    public void PlayPaddleHitSound()
    {
        audioSource.PlayOneShot(paddleHitSound); // Play the paddle hit sound effect
    }

    public void PlayScoreSound()
    {
        audioSource.PlayOneShot(scoreSound); // Play the score sound effect
    }

    void OnDestroy()
    {
        // Unsubscribe from scene loaded event when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
