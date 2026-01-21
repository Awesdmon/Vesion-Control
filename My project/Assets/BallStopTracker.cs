using UnityEngine;

public class BallStopTracker : MonoBehaviour
{
    public Transform targetTransform;   // The transform that will receive the position
    public float stopThreshold = 0.05f;  // How slow is "stopped"


    private Rigidbody rb;
    private bool hasStopped = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (hasStopped)

            return;
        // Optional: only trigger on floor
        if (!collision.gameObject.CompareTag("Floor"))
            return;

        if (rb.linearVelocity.magnitude < stopThreshold)
        {
            hasStopped = true;
            targetTransform.position = transform.position;
        }
    }
}