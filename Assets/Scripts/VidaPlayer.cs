using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public float VidaMaxima = 100;
    public Image BarraVida;

    void Start()
    {

    }


    void Update()
    {
        VidaMaxima = Mathf.Clamp(VidaMaxima, 0, 100);

        BarraVida.fillAmount = VidaMaxima / 100;
    }
}
