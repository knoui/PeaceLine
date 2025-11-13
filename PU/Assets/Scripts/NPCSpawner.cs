using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [Header("NPC Settings")]
    public GameObject npcPrefab;
    public int maxNPCs = 20;
    public float spawnInterval = 2f;
    public float checkRadius = 1f;
    public LayerMask npcLayer; // hanya cek tabrakan antar NPC

    [Header("Area Settings")]
    public Vector3 areaSize = new Vector3(20, 1, 20);

    private int currentCount = 0;
    private float timer = 0f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawCube(transform.position, areaSize);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentCount < maxNPCs)
        {
            TrySpawnNPC();
            timer = 0f;
        }
    }

    void TrySpawnNPC()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-areaSize.x / 2, areaSize.x / 2),
                0, // sedikit di atas tanah
                Random.Range(-areaSize.z / 2, areaSize.z / 2)
            );

            Vector3 spawnPos = transform.position + randomPos;

            // hanya cek tabrakan dengan NPC lain
            bool occupied = Physics.CheckSphere(spawnPos, checkRadius, npcLayer);

            if (!occupied)
            {
                SpawnNPC(spawnPos);
                return;
            }
        }
    }

    void SpawnNPC(Vector3 position)
    {
        GameObject npc = Instantiate(npcPrefab, position, Quaternion.Euler(0, 180, 0));
        npc.name = "NPC_" + currentCount;
        // npc.layer = LayerMask.NameToLayer("NPC"); // pastikan prefab punya layer ini
        
        currentCount++;
    }
}
