using UnityEngine;

public class ProvokatorBehaviour : MonoBehaviour
{
    public float emotionBoost = 5f;
    public float interval = 5f;

    private float timer = 0f;

    void Start()
    {
        gameObject.tag = "Provokator";
        // GameObject label = new GameObject("ProvokatorLabel");
        // TextMesh text = label.AddComponent<TextMesh>();

        // text.text = "PROVOKATOR";
        // text.fontSize = 32;
        // text.color = Color.red;
        // text.characterSize = 0.1f;

        // label.AddComponent<FollowTarget>().target = this.transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            GlobalEmotionManager.Instance.AddEmotion(emotionBoost);
        }
    }
}
