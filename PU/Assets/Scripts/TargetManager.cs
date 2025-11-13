using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<NPCController> npcs = new List<NPCController>();
    public float interval = 5f; // jeda antar pengecekan
    public int maxTargets = 2;  // jumlah target aktif maksimum

    private int currentTargets = 0;

    void Start()
    {
        StartCoroutine(ManageTargetsRoutine());
    }

    IEnumerator ManageTargetsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            // hitung ulang target aktif
            currentTargets = CountActiveTargets();

            // kalau kurang dari batas, tambahkan target baru
            if (currentTargets < maxTargets)
            {
                int needed = maxTargets - currentTargets;
                AssignNewTargets(needed);
            }
        }
    }

    int CountActiveTargets()
    {
        int count = 0;
        foreach (var npc in npcs)
        {
            if (npc != null && npc.isTarget)
                count++;
        }
        return count;
    }

    void AssignNewTargets(int numberToAssign)
    {
        List<NPCController> available = new List<NPCController>(npcs);
        available.RemoveAll(n => n == null || n.isTarget);

        for (int i = 0; i < numberToAssign && available.Count > 0; i++)
        {
            int idx = Random.Range(0, available.Count);
            available[idx].isTarget = true;
            available.RemoveAt(idx);
        }
    }

    public void TargetRemoved()
    {
        currentTargets--;
    }
}
