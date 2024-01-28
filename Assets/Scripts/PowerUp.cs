using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUp : MonoBehaviour
{
    public Rigidbody rb;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Jujador Izquierda
        if (Input.GetKey(KeyCode.K) && transform.position.y < 10.7 && transform.position.y > 8.66)
        {
            Debug.Log("PowerUp Conceguido J I");
            Destroy(gameObject, 0);
        }
        // Jugador Derecha
        if (Input.GetKey(KeyCode.S) && transform.position.y < 10.7 && transform.position.y > 8.66)
        {
            Debug.Log("PowerUp Conceguido J D");
            Destroy(gameObject, 0);
        }
        // El powerup se perdió
        if (transform.position.y < 6.80)
        {
            Destroy(gameObject, 0.3f);
            Debug.Log("Se acabó");
        }
    }
}
