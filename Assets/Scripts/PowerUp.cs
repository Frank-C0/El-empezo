using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUp : MonoBehaviour
{
    private GameObject cubekey;
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 20, transform.position.z);
    }
    public void createCube(GameObject obj, float y_pos)
    {
        Vector3 randomSpawnPosition = new Vector3(transform.position.x, y_pos, transform.position.z);
        cubekey = Instantiate(obj, randomSpawnPosition, Quaternion.identity);
    }
    void Update()
    {
        if (cubekey != null)
        {
            // Jujador Izquierda
            if (Input.GetKeyDown(KeyCode.K) && transform.position.y < cubekey.transform.position.y + 1 && transform.position.y > cubekey.transform.position.y - 1)
            {
                Debug.Log("PowerUp Conceguido J I");
                Destroy(cubekey, 0);
                Destroy(gameObject, 0);
            }
            // Jugador Derecha
            if (Input.GetKeyDown(KeyCode.S) && transform.position.y < cubekey.transform.position.y + 1 && transform.position.y > cubekey.transform.position.y - 1)
            {
                Debug.Log("PowerUp Conceguido J D");
                Destroy(cubekey, 0);
                Destroy(gameObject, 0);
            }
            // El powerup se perdi�
            if (transform.position.y < 2)
            {
                Debug.Log("Se acabo");
                Destroy(gameObject, 0.3f);
                Destroy(cubekey, 0);
            }
        }
    }
}
