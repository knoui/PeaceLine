using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
            transform.position = target.position + Vector3.up * 2f;
    }
}
