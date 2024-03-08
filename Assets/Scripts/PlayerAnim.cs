using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private PlayerController player;
    private Animator playerAnim;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        playerAnim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }



    void Update()
    {
        RunAnim();
        JumpAnim();
    }

    void RunAnim()
    {
        if (player.playerMove)
        {
            playerAnim.SetBool("Run",true);
        }
        else
        {
            playerAnim.SetBool("Run",false);
        }
    }

    void JumpAnim()
    {
        if (!player.isGrounded) // Verifica si el jugador no está en el suelo
        {
            playerAnim.SetBool("Jump", true); // Activa la animación de salto
        }
        else
        {
            playerAnim.SetBool("Jump", false); // Desactiva la animación de salto
        }
    }
}
