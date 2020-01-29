using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits(){
        while(true){
            float delay = Random.Range(minDelay,maxDelay);
            yield return new WaitForSeconds(1f);
            int spawnIndex = Random.Range(0 , spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    }
