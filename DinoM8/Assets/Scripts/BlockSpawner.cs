using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlockSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public float TimeBetweenBlocks = 1F;
    private float TimeToSpawn = 1F;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= TimeToSpawn){
        SpawnBlocks();     
        TimeToSpawn = Time.time + TimeBetweenBlocks;
        }  
    }
    void SpawnBlocks () 
    {
        int randomInedex = Random.Range(0, spawnPoints.Length);
        for(int i = 0; i < spawnPoints.Length; i++)
                {
                    if(randomInedex != i){
                        Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                    }
                }

    }
}
