using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultManager : MonoBehaviour
{
    public static GameResultManager Instance;

    [Header("Timer Settings")]
    public float gameDuration = 120f; // 2 menit
    private float timer;

    [Header("Result Panels")]
    public GameObject winPanel;
    public GameObject losePanel;

    private bool gameEnded = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timer = gameDuration;

        // Pastikan panel tidak tampil di awal
        if (winPanel) winPanel.SetActive(false);
        if (losePanel) losePanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        // Kurangi timer
        timer -= Time.deltaTime;

        // Emosi crowd
        float emo = GlobalEmotionManager.Instance.crowdEmotion;

        // 🔥 1. KALAH jika emosi penuh
        if (emo >= 100f)
        {
            Lose();
            return;
        }

        // 🔥 2. MENANG jika waktu habis dan emosi tidak penuh
        if (timer <= 0f)
        {
            Win();
        }
    }

    public void Win()
    {
        if (gameEnded) return;

        gameEnded = true;

        if (winPanel)
            winPanel.SetActive(true);

        Debug.Log("YOU WIN!");
        Time.timeScale = 0; // pause game
    }

    public void Lose()
    {
        if (gameEnded) return;

        gameEnded = true;

        if (losePanel)
            losePanel.SetActive(true);

        Debug.Log("YOU LOSE!");
        Time.timeScale = 0; // pause game
    }
}
