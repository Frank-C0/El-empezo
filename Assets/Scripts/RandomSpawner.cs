using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public List<GameObject> prefabsToSpawn;
    public float respawnInterval;

    public GameObject cubeKey;
    private bool canRespawn = true;

    public SSControllerScript ssController; // Asigna el objeto SSControllerScript desde el Inspector
    public GameObject objetoJugador; // Asigna el objeto padre deseado desde el Inspector
    public KeyCode key;

    public int powerColorIndex;

    public float power = 2;
    [HideInInspector]
    public float currentPower;
    public float SSmultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnCoroutine());
        currentPower = power;
    }

    IEnumerator RespawnCoroutine()
    {
        while (true)
        {
            if (canRespawn)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z) + randomSpawnPosition;
                GameObject selectedPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Count)]; // Aleatoriedad de powerUp
                PowerUp instanceObj = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity).GetComponent<PowerUp>(); // Instancias ese objeto
                instanceObj.initialize(this, cubeKey, Random.Range(-4, 4) + transform.position.y, key);

                canRespawn = false;
                yield return new WaitForSeconds(respawnInterval);
                canRespawn = true;
            }
            yield return null;
        }
    }


    public void ActivateSuperPowerUp()
    {
        // Asegúrate de que el objeto SSControllerScript y el objeto padre estén asignados
        if (ssController != null && objetoJugador != null)
        {
            applyMultiplier();
            StartCoroutine(removeMultiplier());   
            ssController.ActivateSSPower(objetoJugador, powerColorIndex, 2.4f, 3f);
        }
        else
        {
            Debug.LogError("Asegúrate de asignar el objeto SSControllerScript y el objetoJugador en el Inspector.");
        }
    }

    void applyMultiplier()
    { 
        currentPower = currentPower * SSmultiplier;
    }
    IEnumerator removeMultiplier()
    {
        yield return new WaitForSeconds(2.8f);
        currentPower = currentPower / SSmultiplier;
    }

}
