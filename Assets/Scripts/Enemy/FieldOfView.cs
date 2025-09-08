using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius = 8f;
    [Range(0,360)]
    public float viewAngle = 60f;
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool CanSeeTarget(Transform target)
    {
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist > viewRadius) return false;

        float angleBetween = Vector3.Angle(transform.forward, dirToTarget);
        if (angleBetween > viewAngle / 2f) return false;

        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dirToTarget, out RaycastHit hit, viewRadius, obstructionMask))
        {
            if (hit.transform != target && !hit.transform.CompareTag("Player"))
                return false;
        }
        return true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
        Vector3 leftDir = Quaternion.Euler(0, -viewAngle/2f, 0) * transform.forward;
        Vector3 rightDir = Quaternion.Euler(0, viewAngle/2f, 0) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + leftDir * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + rightDir * viewRadius);
    }
}
