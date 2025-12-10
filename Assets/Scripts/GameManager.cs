using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Settings")]
    public float gameDuration = 600f; // 10 minutes in seconds
    public int totalPackages = 5;

    [Header("Current State")]
    public float timeRemaining;
    public int packagesDelivered = 0;
    public int score = 0;
    public bool gameActive = false;

    private UIManager uiManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        StartGame();
    }

    void Update()
    {
        if (gameActive)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                EndGame(false);
            }

            if (uiManager != null)
            {
                uiManager.UpdateTimer(timeRemaining);
            }
        }
    }

    public void StartGame()
    {
        timeRemaining = gameDuration;
        packagesDelivered = 0;
        score = 0;
        gameActive = true;
    }

    public void DeliverPackage(int points)
    {
        packagesDelivered++;
        score += points;

        if (uiManager != null)
        {
            uiManager.UpdateDeliveryCount(packagesDelivered);
        }

        Debug.Log($"Deal delivered! Total deals: {packagesDelivered}, Score: {score}");

        if (packagesDelivered >= totalPackages)
        {
            EndGame(true);
        }
    }

    void EndGame(bool success)
    {
        gameActive = false;

        if (success)
        {
            Debug.Log($"Victory! All {totalPackages} deals delivered. Final score: {score}");
        }
        else
        {
            Debug.Log($"Time's up! Delivered {packagesDelivered}/{totalPackages} deals. Score: {score}");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
