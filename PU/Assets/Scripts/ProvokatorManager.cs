using System.Collections.Generic;
using UnityEngine;

public class ProvokatorManager : MonoBehaviour
{
    public static ProvokatorManager Instance;

    [Header("Provokator Settings")]
    public int maxProvokators = 2;      // jumlah maksimal provokator aktif
    public float provokatorInterval = 10f; // jeda waktu untuk memilih provokator baru

    private float timer = 0f;

    private List<NPCArrival> candidates = new List<NPCArrival>();
    private List<NPCArrival> activeProvokators = new List<NPCArrival>();

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= provokatorInterval)
        {
            timer = 0f;
            TryPickProvokator();
        }
    }

    public void RegisterNPC(NPCArrival npc)
    {
        if (!candidates.Contains(npc))
            candidates.Add(npc);
    }

    void TryPickProvokator()
    {
        // Sudah maksimal? tidak perlu tambah
        if (activeProvokators.Count >= maxProvokators) return;
        if (candidates.Count == 0) return;

        // Pilih NPC random yang bukan provokator
        NPCArrival npc = candidates[Random.Range(0, candidates.Count)];

        if (!activeProvokators.Contains(npc))
        {
            activeProvokators.Add(npc);
            npc.gameObject.AddComponent<ProvokatorBehaviour>(); // kasih dia status provokator
        }
    }
}
