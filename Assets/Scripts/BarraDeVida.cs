using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    // Update is called once per frame
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;

    public RandomSpawner playerLeft;
    public RandomSpawner playerRight;
    void start(){
        vidaActual = vidaMaxima/2;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddLeft();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddRight();
        }
        vidaActual = Mathf.Clamp(vidaActual, 0f, vidaMaxima);
        barraDeVida.fillAmount=vidaActual/vidaMaxima;

    }
    // Método para aumentar la vida
    void AddRight()
    {
        // if()
        vidaActual -= playerRight.currentPower; // Puedes ajustar el valor de aumento según tus necesidades
        print(playerRight.currentPower);
    }

    // Método para disminuir la vida
    void AddLeft()
    {
        vidaActual += playerLeft.currentPower; // Puedes ajustar el valor de disminución según tus necesidades
        print(playerLeft.currentPower);

    }
    
}
