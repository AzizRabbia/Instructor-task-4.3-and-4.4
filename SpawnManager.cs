using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave();
    }


    void SpawnEnemyWave() 
    {
      for(int i = 0;i < 3;i++) 
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    
    }


    private Vector3 GenerateSpawnPosition()
    {
        float spawnposX = 512.09f;
 
        float spawnposZ = 251.84f;
        Vector3 spawnRange = new Vector3(spawnposX, 0, spawnposZ);
        return spawnRange;

    }
   // Update is called once per frame
   void Update()
    {
        
 }
}
