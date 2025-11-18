using UnityEngine;

public class ProvokatorBehaviour : MonoBehaviour
{
    public Color provokatorColor = Color.red;
    public float emotionBoost = 5f;
    public float interval = 3f;

    private float timer;
    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        // ambil renderer NPC
        rend = GetComponentInChildren<Renderer>();

        if (rend != null)
        {
            // simpan warna asli
            originalColor = rend.material.color;

            // ubah ke merah
            rend.material.color = provokatorColor;
        }
        else
        {
            Debug.LogWarning("Renderer tidak ditemukan di NPC!");
        }

        // ubah tag (opsional, untuk interaksi player)
        gameObject.tag = "Provokator";
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;

            if (GlobalEmotionManager.Instance != null)
                GlobalEmotionManager.Instance.AddEmotion(emotionBoost);
        }
    }

    // opsional kalau ingin mengembalikan warna saat provokator dihapus
    void OnDestroy()
    {
        if (rend != null)
            rend.material.color = originalColor;
    }
}
