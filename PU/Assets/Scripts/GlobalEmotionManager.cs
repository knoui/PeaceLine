using UnityEngine;

public class GlobalEmotionManager : MonoBehaviour
{
    public static GlobalEmotionManager Instance;

    [Range(0f, 100f)]
    public float crowdEmotion = 10f;  // 0 = tenang, 100 = sangat agresif

    public float decayRate = 1f; // emosi turun pelan per detik

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        crowdEmotion = Mathf.Clamp(crowdEmotion - decayRate * Time.deltaTime, 0f, 100f);
    }

    public void AddEmotion(float amount)
    {
        crowdEmotion = Mathf.Clamp(crowdEmotion + amount, 0f, 100f);
    }
}
