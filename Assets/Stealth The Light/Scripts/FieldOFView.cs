using UnityEngine;

public class FieldOFView : MonoBehaviour
{

    [Header("Field of View Settings")]
    [SerializeField] float viewAngle = 90f;
    [SerializeField] float viewDistance = 10f;
    private LayerMask obstructionMask;
    [SerializeField] string playerTag = "Player";

    Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player != null && IsPlayerInSight())
        {
            Debug.Log("GameOver");

        }
    }

    bool IsPlayerInSight()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > viewDistance)
            return false;

        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        if (angle > viewAngle / 2f)
            return false;


        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out RaycastHit hit, viewDistance, ~obstructionMask))
        {
            if (hit.collider.CompareTag(playerTag))
                return true;
        }

        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector3 origin = transform.position;
        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2f, 0) * transform.forward * viewDistance;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2f, 0) * transform.forward * viewDistance;

        Gizmos.DrawRay(origin, leftBoundary);
        Gizmos.DrawRay(origin, rightBoundary);
        Gizmos.DrawWireSphere(origin, viewDistance);
    }
}
