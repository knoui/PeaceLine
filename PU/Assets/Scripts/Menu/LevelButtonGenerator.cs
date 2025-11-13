using UnityEngine;
using UnityEngine.UI;
using TMPro; // <-- Tambahkan ini
using System.Collections.Generic;

public class LevelButtonGenerator : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public Transform buttonContainer;
    public int totalLevels = 5;

    void Start()
    {
        GenerateLevelButtons();
    }

    void GenerateLevelButtons()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
            GameObject button = Instantiate(levelButtonPrefab, buttonContainer);
            
            // Gunakan TMP_Text, bukan Text
            TMP_Text textComponent = button.GetComponentInChildren<TMP_Text>();
            
            if (textComponent != null)
            {
                textComponent.text = "Level " + i;
            }
            else
            {
                Debug.LogError("Tidak ada TMP_Text di dalam prefab tombol level! Periksa struktur prefab.");
            }

            int levelIndex = i;
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    void LoadLevel(int levelIndex)
    {
        FindFirstObjectByType<MenuManager>()?.LoadLevel(levelIndex);
    }
}