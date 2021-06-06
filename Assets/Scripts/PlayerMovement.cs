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

    Animator anim;
    private float pushForce;

    [SerializeField] private Vector3 checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(transform.position.y < -10)
        {
            transform.position = checkpoint;
        }
    }

    public void Move()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        
        if(isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //walk
                Walk();
                anim.SetTrigger("Run");
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //run
                Run();
                anim.SetTrigger("Sprint");
            }
            else if (moveDirection == Vector3.zero)
            {
                //idle
                Idle();
                anim.SetTrigger("Idle");
            }
            moveDirection *= playerspeed;
            if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
            {
                anim.SetTrigger("Jump");
                Invoke("Jump", 0f);
                //Jump();
            }
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            Vector3 targetDir = moveDirection; //Direction of the character

            targetDir.y = 0;
            if (targetDir == Vector3.zero)
                targetDir = transform.forward;
            Quaternion tr = Quaternion.LookRotation(targetDir); //Rotation of the character to where it moves
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, Time.deltaTime * rotationforce); //Rotate the character little by little
            transform.rotation = targetRotation;
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
        isgrounded = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isgrounded = true;
            anim.SetTrigger("Idle");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckPoint")
        {
            checkpoint = transform.position;
        }
    }

    public void BouncePlayer(float force)
    {
        velocity.y = Mathf.Sqrt(force * -2 * gravity);
        anim.SetTrigger("Jump");
    }
    public void BouncePendulum(float force, float angle)
    {
        pushForce = force;
        if(angle < 0)
        {
            velocity.x = -Mathf.Sqrt(force * -2 * gravity);
            Invoke("playerBounceCorrection", 1);
        }
        else if(angle > 0)
        {
            velocity.x = Mathf.Sqrt(force * -2 * gravity);
            Invoke("playerBounceCorrection", 1);
        }
        
    }
    public void playerBounceCorrection()
    {
        velocity.x = 0;
    }
}
