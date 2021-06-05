using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerspeed = 0f;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float rotationforce = 10f;
    public float jumpHeight;

    private Vector3 moveDirection;
    private CharacterController controller;
    private Vector3 velocity;
    [SerializeField] private float gravity;

    private bool isgrounded;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal") * rotationforce * Time.deltaTime;
        transform.Rotate(Vector3.up, moveX);
        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        if(isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isgrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //walk
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //run
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                //idle
                Idle();
            }
            moveDirection *= playerspeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        
        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Idle()
    {

    }
    private void Walk()
    {
        playerspeed = walkSpeed;
    }
    private void Run()
    {
        playerspeed = runSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isgrounded = true;
        }
    }
}
