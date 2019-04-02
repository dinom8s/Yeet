using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlockSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform[] spawnPoints;
    public GameObject[] blockPrefabs;
    public float TimeBetweenBlocks = 0.35F;
    private float TimeToSpawn = 1.35F;
    private float TimeToSpawnRandom = 10f;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= TimeToSpawn)
        {
            SpawnBlocks();
            TimeToSpawn = Time.time + TimeBetweenBlocks;
            
        } 
        
            if(Time.time >= TimeToSpawnRandom)
            {
                int randomSpawn = Random.Range(0, 10);
                //Debug.Log(randomSpawn); //detta skriver in ranodmindexen i consolen. Detta gör jag för att kolla så random.range fungerade som jag
                if(randomSpawn == 1)
                {
                    SpawnBlocks();
                    
                    TimeToSpawnRandom = Time.time + TimeBetweenBlocks;
                }
            
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
