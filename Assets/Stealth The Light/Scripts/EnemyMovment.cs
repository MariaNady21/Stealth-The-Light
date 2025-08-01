using UnityEngine;

public class EnemyMovment : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform target;
    // [SerializeField] float fieldOfViewAngle = 60f;

    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    RotateToTarget();
        //}

        Vector3 position = transform.position;
        position.x = Mathf.Sin(Time.time) * 3;
        transform.position = position;

        CheckVision();

        float direction = Mathf.Cos(Time.time);
        FaceDirection(direction);


        //if (direction > 0)
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
    }

    void RotateToTarget()
    {
        //float horizontal = target.position.x - transform.position.x;
        //float vertical = target.position.z - transform.position.z;

        //float degree = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, degree, 0);
    }

    void CheckVision()
    {
        //Vector3 toTarget = (target.position - transform.position).normalized;
        //Vector3 forward = transform.right;

        //float dot = Vector3.Dot(forward, toTarget);
        //float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        //if (angle < fieldOfViewAngle)
        //{
        //    Debug.Log(" I can see the target!");
        //}
        //else
        //{
        //    Debug.Log("Target out of sight.");
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, target.position);

        //Matrix4x4 matrix = transform.localToWorldMatrix;
        //Gizmos.matrix = matrix;

        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(Vector3.zero, Vector3.right); // X

        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(Vector3.zero, Vector3.up); // Y

        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(Vector3.zero, Vector3.forward); // Z
    }
    void FaceDirection(float moveDirection)
    {
        if (moveDirection > 0)
        {

            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (moveDirection < 0)
        {

            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
