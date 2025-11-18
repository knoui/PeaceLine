using UnityEngine;
using UnityEngine.AI;

public class NPCArrival : MonoBehaviour
{
    public float arrivalDistance = 0.5f;

    private NavMeshAgent agent;
    private Animator anim;
    private bool hasArrived = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        // Set demoIndex ke nilai "tidak valid" agar animator tidak langsung transit ke Demo1
        if (anim != null)
            anim.SetInteger("demoIndex", -1);
    }

    void Update()
    {
        if (hasArrived) return;
        if (agent == null) return;
        if (!agent.pathPending && agent.remainingDistance <= arrivalDistance)
        {
            ArrivedAtRallyPoint();
        }
    }

    void ArrivedAtRallyPoint()
    {
        hasArrived = true;

        if (agent != null)
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }

        if (anim != null)
            anim.SetBool("isWalking", false);

        if (anim != null)
        {
            int randomDemo = Random.Range(0, 1); // 0..3
            anim.SetInteger("demoIndex", randomDemo);
        }

        if (ProvokatorManager.Instance != null)
            ProvokatorManager.Instance.RegisterNPC(this);
    }
}
