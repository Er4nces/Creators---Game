using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipuladorVida : MonoBehaviour
{
    VidaPlayer playerVida;

    public int Cantidad;
    public float DamageTime;
    float CurrrentDamageTime;


    void Start()
    {
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            CurrrentDamageTime += Time.deltaTime;
            if (CurrrentDamageTime > DamageTime)
            {
                playerVida.VidaMaxima += Cantidad;
                CurrrentDamageTime = 0.0f;
            }
        }
    }


    void Update()
    {
        
    }
}
