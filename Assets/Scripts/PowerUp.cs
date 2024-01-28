using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUp : MonoBehaviour
{
    private GameObject cubekey;
    private RandomSpawner spawner;
    private KeyCode key;
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 20, transform.position.z);
    }
    public void initialize(RandomSpawner spawner, GameObject obj, float y_pos, KeyCode key)
    {
        Vector3 randomSpawnPosition = new Vector3(transform.position.x, y_pos, transform.position.z);
        cubekey = Instantiate(obj, randomSpawnPosition, Quaternion.identity);
        this.spawner = spawner;
        this.key = key;
    }
    void Update()
    {
<<<<<<< HEAD
        // Jujador Izquierda
        if (Input.GetKey(KeyCode.S) && transform.position.y < 10.7 && transform.position.y > 8.66)
        {
            Debug.Log("PowerUp Conceguido J D");
            Destroy(gameObject, 0);
        }
        // Jugador Derecha
        if (Input.GetKey(KeyCode.K) && transform.position.y < 10.7 && transform.position.y > 8.66)
        {
            Debug.Log("PowerUp Conceguido J I");
            Destroy(gameObject, 0);
        }
        // El powerup se perdió
        if (transform.position.y < 6.80)
        {
            Destroy(gameObject, 0.3f);
            Debug.Log("Se acabó");
=======
        if (cubekey != null)
        {
            // Jujador Izquierda
            if (Input.GetKeyDown(key) && transform.position.y < cubekey.transform.position.y + 1 && transform.position.y > cubekey.transform.position.y - 1)
            {
                spawner.ActivateSuperPowerUp();
                Debug.Log("PowerUp Conceguido");
                Destroy(cubekey, 0);
                Destroy(gameObject, 0);
            }
            // El powerup se perdiï¿½
            if (transform.position.y < 2)
            {
                Debug.Log("Se acabo");
                Destroy(gameObject, 0.3f);
                Destroy(cubekey, 0);
            }
>>>>>>> dev_frank
        }
    }

    

}
