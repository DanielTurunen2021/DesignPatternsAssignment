using UnityEngine;

public class StateMachineMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5f;
    private float jumpspeed = 15f;
    
    enum State
    {
        moving,
        jumping,
        falling
    }

    enum SecondState
    {
        moveinair,
        crouch,
        standing
    }

    private State _currentState;
    private SecondState _currentSecondState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case State.moving:
                Move();
                break;
            case State.jumping:
                Jump();
                break;
        }
        
        switch(_currentSecondState)
        {
            case SecondState.moveinair:
                MoveInAir();
                break;
            case SecondState.crouch:
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case SecondState.standing:
                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
        }

        if (Input.GetKeyDown(KeyCode.Q) && HealthPotion.HpPotion.hp_potion_amount > 0)
        {
            HealthPotion.HpPotion.AddHealth();
            HealthPotion.HpPotion.hp_potion_amount -= 1;
        }

        if (Input.GetKeyDown(KeyCode.E) && ManaPotion.MpPotion.mp_potion_amount > 0 )
        {
            ManaPotion.MpPotion.AddMana();
            ManaPotion.MpPotion.mp_potion_amount -= 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                _currentState = State.moving;
            }
            if(Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Space) 
                    || (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Space) || 
                        (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space) || 
                         (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space)))))
            {
                _currentState = State.jumping;
                _currentSecondState = SecondState.moveinair;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _currentSecondState = SecondState.crouch;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                _currentState = State.jumping;
                _currentSecondState = SecondState.moveinair;
            }
            else 
            {
                _currentSecondState = SecondState.standing;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("Ground"))
       {
           _currentState = State.falling;
           _currentSecondState = SecondState.moveinair;
       }
    }
    
    //Movement on the ground
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.forward *speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left *speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.back *speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right *speed;
        }
    }
    
    //Movement in the air
    private void MoveInAir()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector3.forward *speed *Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector3.left *speed *Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += Vector3.back *speed *Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += Vector3.right *speed *Time.deltaTime;
        }
    }

    private void Jump()
    {
        rb.velocity = Vector3.up *jumpspeed;
    }
}
