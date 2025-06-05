using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public List<Transform> spawnPoints;
    public float respawnDelay = 2f;

    void Start()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint.childCount == 0)
            {
                SpawnCoinAt(spawnPoint);
            }
        }
    }

    public void SpawnCoinAt(Transform spawnPoint)
    {
        GameObject coin = Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
        coin.transform.localPosition = Vector3.zero;
    }

    public void RespawnAt(Transform spawnPoint)
    {
        StartCoroutine(RespawnDelay(spawnPoint));
    }

    private IEnumerator RespawnDelay(Transform spawnPoint)
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnCoinAt(spawnPoint);
    }
}
