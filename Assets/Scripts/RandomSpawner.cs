using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public List<GameObject> prefabsToSpawn;
    public float respawnInterval;

    public GameObject cubeKey;
    private bool canRespawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnCoroutine());
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
                instanceObj.createCube(cubeKey, Random.Range(-4, 4) + transform.position.y);

                canRespawn = false;
                yield return new WaitForSeconds(respawnInterval);
                canRespawn = true;
            }
            yield return null;
        }
    }
}
