using UnityEngine;

public class ParticleSpeed : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 0.25f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up *speed;
    }
}
