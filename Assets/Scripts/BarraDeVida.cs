using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Update is called once per frame
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            AumentarVida();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DisminuirVida();
        }
        vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima);
        barraDeVida.fillAmount=vidaActual/vidaMaxima;

    }
    // Método para aumentar la vida
    void AumentarVida()
    {
        vidaActual += 10f; // Puedes ajustar el valor de aumento según tus necesidades
    }

    // Método para disminuir la vida
    void DisminuirVida()
    {
        vidaActual -= 10f; // Puedes ajustar el valor de disminución según tus necesidades
    }
}
