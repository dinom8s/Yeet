using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlockSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform[] spawnPoints;
    public GameObject[] blockPrefabs;
    public float TimeBetweenBlocks = 0.35F;
    public float TimeToSpawn = 1.35F;
    public float TimeToSpawnRandom = 10f;
    public float TimeToStart = 0f;
    void Start()
    {
        TimeToSpawn = Time.time + 1.35F;
        TimeToSpawnRandom = Time.time + 10F;

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(TimeToStart);
        
        if(Time.time + TimeToStart >= TimeToSpawn)
        {
            SpawnBlocks();
            TimeToSpawn = Time.time + TimeToStart + TimeBetweenBlocks;
        } 
        
            if(Time.time + TimeToStart  >= TimeToSpawnRandom)
            {
              //  Debug.Log(TimeToStart);
                int randomSpawn = Random.Range(0, 10);
               // Debug.Log(randomSpawn); //detta skriver in ranodmindexen i consolen. Detta gör jag för att kolla så random.range fungerade som jag
                //if(randomSpawn == 1)
                //{
                  //  SpawnBlocks();
                    
                    //TimeToSpawnRandom = Time.time + TimeToStart + TimeBetweenBlocks;
                //} 
            
        }
        
    
    }
    void SpawnBlocks () 
    {
        for(int i = 0; i < spawnPoints.Length; i++)
                {
                    
            int randomIndex = Random.Range(0, blockPrefabs.Length);
                     Instantiate(blockPrefabs[randomIndex], spawnPoints[i].position, Quaternion.identity);
                }

    }
}
