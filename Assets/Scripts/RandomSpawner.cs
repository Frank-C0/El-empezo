using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public List<GameObject> prefabsToSpawn;
    public float respawnInterval;
    private bool canRespawn = true;
    public float ejeX, ejeZ, ejeY;

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
                //Vector3 randomSpawnPosition = new Vector3(Random.Range(15f, 35f), 13f, Random.Range(13f, 40f));
                Vector3 randomSpawnPosition = new Vector3(ejeX, ejeY, ejeZ);
                GameObject selectedPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Count)]; // Aleatoriedad de powerUp
                Instantiate(selectedPrefab, randomSpawnPosition, Quaternion.identity); // Instancias ese objeto
                canRespawn = false;
                yield return new WaitForSeconds(respawnInterval);
                canRespawn = true;
            }
            yield return null;
        }
    }
}
