using UnityEngine;
using UnityEngine.AI;

public class NPCArrival : MonoBehaviour
{
    public bool hasArrived = false;
    public float arrivalDistance = 2f;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (hasArrived) return;
        if (agent == null) return;
        if (!agent.enabled) return;
        if (agent.pathPending) return;
        if (agent.pathStatus != NavMeshPathStatus.PathComplete) return;

        // jika agent kehilangan path, remainingDistance bisa error
        if (float.IsInfinity(agent.remainingDistance) || float.IsNaN(agent.remainingDistance))
            return;

        if (agent.remainingDistance <= arrivalDistance)
        {
            hasArrived = true;
            ProvokatorManager.Instance.RegisterNPC(this);
        }
    }

}
