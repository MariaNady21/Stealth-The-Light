using UnityEngine;

public class CameraAAttack : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] float rotationSpeed = 1f;

    [Header("Detection Settings")]
    [SerializeField] string playerTag = "Player";

    Quaternion rotationA;
    Quaternion rotationB;
    bool toB = true;
    float t = 0f;

    void Start()
    {

        rotationA = Quaternion.Euler(0f, -50f, 0f);
        rotationB = Quaternion.Euler(0f, 180f, 0f);
    }

    void Update()
    {
        t += Time.deltaTime * rotationSpeed;

        if (toB)
            transform.localRotation = Quaternion.Slerp(rotationA, rotationB, t);
        else
            transform.localRotation = Quaternion.Slerp(rotationB, rotationA, t);

        if (t >= 1f)
        {
            t = 0f;
            toB = !toB;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("game over");
        }
    }
}
