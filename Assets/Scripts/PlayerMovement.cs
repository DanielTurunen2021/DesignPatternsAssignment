using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    //meters/seconds
    private float speed = 1f;
    private float jump = 10f;
    private bool isJumping = false;
    private bool isCrouching = false;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (isJumping == false)
            {
                rb.velocity = Vector3.forward *speed;
            }
            else
            {
                rb.velocity += Vector3.forward *jump  *Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (isJumping == false)
            {
                rb.velocity = Vector3.left *speed;
            }
            else
            {
                rb.velocity += Vector3.left *jump *Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (isJumping == false)
            {
                rb.velocity = Vector3.back *speed;
            }
            else
            {
                rb.velocity += Vector3.back *jump *Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (isJumping == false)
            {
                rb.velocity = Vector3.right *speed;
            }
            else
            {
                rb.velocity += Vector3.right *jump * Time.deltaTime;
            }
        }
        
        //jump

        if ( isJumping == false && isCrouching == false  && Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            rb.velocity = Vector3.up *jump;
        }
        //crouch

        if (isJumping != true && Input.GetKey(KeyCode.LeftShift))
        {
            isCrouching = true;
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            speed = 0.5f;
        }
        else
        {
            isCrouching = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
            speed = 1f;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
