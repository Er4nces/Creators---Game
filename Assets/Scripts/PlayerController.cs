using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerRotate;
    public float playerSpeed;
    //public float jumpSpeed;
    public bool playerMove = false;
    private Rigidbody rb;
    private Vector3 displacement;
    //public bool checkGround = true;
    //public Transform chkGround;


    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public bool isGrounded;
    private bool canJump = true; // Variable para controlar si el personaje puede saltar


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
    }

    void Update()
    {
        float mh = Input.GetAxis("Horizontal");
        PlayerMove(mh);
        PlayerJump();

        



    }

    void PlayerMove(float mh)
    {
        displacement.Set(0f, 0f, mh);
        displacement = displacement.normalized * playerSpeed * Time.deltaTime;
        rb.MovePosition (transform.position + displacement);

        if(mh != 0f)
        {
            PlayerRotate(mh);
        }

        bool playerRun = mh != 0f;
        if(playerRun)
        {
            playerMove = true;
        }
        else
        {
            playerMove = false;
        }
    }

    void PlayerRotate (float mh)
    {
        float interpolation = playerRotate * Time.deltaTime;
        Vector3 targetDirection = new Vector3 (0f, 0f, mh);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection,Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, interpolation);
        rb.MoveRotation(newRotation);
    }
    
    void PlayerJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            canJump = true; // Si está en el suelo, permitir saltar
        }

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpForce;
            canJump = false; // Desactivar la capacidad de saltar hasta que esté en el suelo nuevamente
        }
    }
    


}
