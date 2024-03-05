using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerRotate;
    public float playerSpeed;
    public float jumpSpeed;
    public bool playerMove = false;
    private Rigidbody rb;
    private Vector3 displacement;
    public bool checkGround = true;
    public Transform chkGround;

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
        Vector3 dwn = transform.TransformDirection(Vector3.down);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Space) && checkGround)
        {
            Debug.Log("salto");
            rb.velocity = new Vector3(0f, jumpSpeed, 0f);
            checkGround = false;
        }
        if (Physics.Raycast(chkGround.position, dwn, out hit, 0.2f) && hit.collider.CompareTag("Ground")) 
        {
            checkGround = true;
        }
        else
        {
            checkGround = false ;
        }
    }
}
