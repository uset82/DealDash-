using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Text timerText;
    public Text deliveryCountText;

    void Start()
    {
        if (timerText != null)
        {
            timerText.text = "10:00";
        }

        if (deliveryCountText != null)
        {
            deliveryCountText.text = "Deals: 0/5";
        }
    }

    public void UpdateTimer(float timeRemaining)
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void UpdateDeliveryCount(int delivered)
    {
        if (deliveryCountText != null)
        {
            int total = GameManager.Instance != null ? GameManager.Instance.totalPackages : 5;
            deliveryCountText.text = $"Deals: {delivered}/{total}";
        }
    }
}
