using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject indicator;
    public bool isTarget = false;
    public float clickDistance = 3f;
    private Camera cam;
    private TargetManager manager; // referensi ke pengatur target

    void Start()
    {
        cam = Camera.main;
        if (cam == null)
            Debug.LogError("Camera with tag 'MainCamera' not found!");

        manager = FindFirstObjectByType<TargetManager>();
        if (indicator != null)
            indicator.SetActive(false);
    }

    void Update()
    {
        if (indicator != null)
            indicator.SetActive(isTarget);

        // klik kiri mouse
        if (Input.GetKeyDown(KeyCode.Space) && isTarget && cam != null)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    float dist = Vector3.Distance(cam.transform.position, transform.position);
                    if (dist <= clickDistance)
                    {
                        // hilangkan NPC target
                        Destroy(gameObject);
                        // beri tahu manager bahwa 1 target sudah hilang
                        if (manager != null)
                            manager.TargetRemoved();
                    }
                }
            }
        }
    }
}
