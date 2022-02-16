using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float maxSpawnTime = 6;
    [SerializeField] float minSpawnTime = 3;
    [SerializeField] float spawnTime;
    [SerializeField] float xRange;
    [SerializeField] float zRange;
    [SerializeField] float y = 3;

    [SerializeField] Enemy enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        spawnTime = minSpawnTime;
    }

    private void Update()
    {
        if (GameManager.Instance.gameRunning)

        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            Spawn();
            spawnTime += Random.Range(minSpawnTime, maxSpawnTime);
        }


    }

    void Spawn()
    {
        float x = Random.Range(-xRange, xRange);
        float z = Random.Range(-zRange, zRange);
        Enemy enemy = Instantiate(enemyPrefab, new Vector3(x,y,z),enemyPrefab.transform.rotation);
        Invoke("Spawn", Random.Range(minSpawnTime, maxSpawnTime));
    }
  
}
