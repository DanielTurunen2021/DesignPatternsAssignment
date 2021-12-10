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
        standing,
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
            case State.falling:
                //rb.velocity = Vector3.down;
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

        if (Input.GetKeyDown(KeyCode.Q) && Inventory.HealthPotion.hp_potion_amount > 0)
        {
            Inventory.HealthPotion.AddHealth();
            //Inventory.HealthPotion.hp_potion_amount -= 1;
            Inventory.ChangeHealth(PlayerProfile.Instance.playerHealth);
            Inventory.useHealthPotion(Inventory.HealthPotion.hp_potion_amount);
        }

        if (Input.GetKeyDown(KeyCode.E) && Inventory.manaPotion.mp_potion_amount > 0)
        {
            Inventory.manaPotion.AddMana();
            //Inventory.manaPotion.mp_potion_amount -= 1;
            Inventory.ChangeMana(PlayerProfile.Instance.playerMana);
            Inventory.useManaPotion(Inventory.manaPotion.mp_potion_amount);
        }
        /*
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _currentState = State.moving;
        }
        */

        if (_currentState == State.falling && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _currentSecondState = SecondState.moveinair;
        }
        
        /*if((Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Space)
            || (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Space) || 
                (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space) || 
                 (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))))))
        {
            _currentState = State.jumping;
            _currentSecondState = SecondState.moveinair;
        }
        */

        if(Input.GetKey(KeyCode.LeftShift))
        {
            _currentSecondState = SecondState.crouch;
            _currentState = State.moving;
        } 
        if (Input.GetKeyDown(KeyCode.Space) && _currentState == State.moving)
        {
            _currentState = State.jumping;
            _currentSecondState = SecondState.moveinair;
        }
        
            
}

private void OnCollisionExit(Collision other)
{
    if (other.gameObject.CompareTag("Ground"))
    {
        _currentState = State.falling;
        _currentSecondState = SecondState.moveinair;
    }
}

private void OnCollisionEnter(Collision other)
{
    if (other.gameObject.CompareTag("Ground"))
    {
        _currentState = State.moving;
        _currentSecondState = SecondState.standing;
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
