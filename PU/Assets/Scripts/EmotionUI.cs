using UnityEngine;
using UnityEngine.UI;

public class EmotionUI : MonoBehaviour
{
    public Slider emotionSlider;

    void Start()
    {
        // Jika belum di-set di Inspector, coba auto-find
        if (emotionSlider == null)
            emotionSlider = GetComponent<Slider>();
    }

    void Update()
    {
        if (GlobalEmotionManager.Instance != null)
        {
            emotionSlider.value = GlobalEmotionManager.Instance.crowdEmotion;
        }
    }
}
