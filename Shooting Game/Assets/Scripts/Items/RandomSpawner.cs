using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public GameObject medkitPrefab;
    public GameObject greenammoPrefab;
    public GameObject blueammoPrefab;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    //starts the coroutines to spawn enemies and items
    void Start()
    {
        StartCoroutine(SpawnItemsAfterTime());
        StartCoroutine(SpawnEnemiesAfterTime());
    }

    //functions to spawn the items and enemies at random places on the map
    public void SpawnMedKit()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 26), 3, Random.Range(-25, 26));
        Instantiate(medkitPrefab, randomSpawnPosition, Quaternion.identity);
    }
    public void SpawnGreenAmmo()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 26), 3, Random.Range(-25, 26));
        Instantiate(greenammoPrefab, randomSpawnPosition, Quaternion.identity);
    }
    public void SpawnBlueAmmo()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 26), 3, Random.Range(-25, 26));
        Instantiate(blueammoPrefab, randomSpawnPosition, Quaternion.identity);
    }
    public void SpawnEnemy1()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 26), 3, Random.Range(-25, 26));
        Instantiate(enemy1, randomSpawnPosition, Quaternion.identity);
    }
    public void SpawnEnemy2()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 26), 3, Random.Range(-25, 26));
        Instantiate(enemy2, randomSpawnPosition, Quaternion.identity);
    }
     public void SpawnEnemy3()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 26), 3, Random.Range(-25, 26));
        Instantiate(enemy3, randomSpawnPosition, Quaternion.identity);
    }   
    public void SpawnEnemy4()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-25, 26), 3, Random.Range(-25, 26));
        Instantiate(enemy4, randomSpawnPosition, Quaternion.identity);
    }

    //spawns items with a 15 second cooldown
    IEnumerator SpawnItemsAfterTime() 
    {
        SpawnMedKit();
        SpawnBlueAmmo();
        SpawnGreenAmmo();
        yield return new WaitForSeconds(15);
        StartCoroutine(SpawnItemsAfterTime());
    }

    //spawns enemies with a 25 second cooldown
    IEnumerator SpawnEnemiesAfterTime() 
    {
        SpawnEnemy1();
        SpawnEnemy2();
        SpawnEnemy3();
        SpawnEnemy4();
        yield return new WaitForSeconds(25);
        StartCoroutine(SpawnEnemiesAfterTime());
    }
}
