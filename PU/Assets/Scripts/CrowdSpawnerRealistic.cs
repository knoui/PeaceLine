using UnityEngine;
using UnityEngine.AI;

public class CrowdSpawnerRealistic : MonoBehaviour
{
    [Header("NPC Settings")]
    public GameObject npcPrefab;

    [Header("Batch Spawn Settings")]
    public int minNPCPerBatch = 3;
    public int maxNPCPerBatch = 6;

    public float minBatchInterval = 3f;
    public float maxBatchInterval = 8f;

    [Header("Spawn Area")]
    public Transform[] spawnPoints;    // titik masuk (jalan)
    public Transform[] rallyPoints;    // tempat demo

    private float nextBatchTime;

    void Start()
    {
        SetNextBatchTime();
    }

    void Update()
    {
        if (Time.time >= nextBatchTime)
        {
            SpawnBatch();
            SetNextBatchTime();
        }
    }

    void SpawnBatch()
    {
        int npcCount = Random.Range(minNPCPerBatch, maxNPCPerBatch + 1);

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        for (int i = 0; i < npcCount; i++)
        {
            // Posisi spawn sedikit menyebar
            Vector3 offset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

            GameObject npc = Instantiate(npcPrefab, spawnPoint.position + offset, Quaternion.identity);

            var agent = npc.GetComponent<NavMeshAgent>();

            // Pilih rally point acak
            Transform rally = rallyPoints[Random.Range(0, rallyPoints.Length)];

            // Arahkan NPC ke area acak di sekitar rally point
            Vector3 rallyOffset = new Vector3(
                Random.Range(-7f, 7f),
                0,
                Random.Range(-7f, 7f)
            );

            agent.SetDestination(rally.position + rallyOffset);
        }
    }


    void SetNextBatchTime()
    {
        nextBatchTime = Time.time + Random.Range(minBatchInterval, maxBatchInterval);
    }
}
