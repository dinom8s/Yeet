﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform[] spawnPoints;
    public GameObject[] blockPrefabs;
    public float TimeBetweenBlocks = 1F;
    public float TimeToSpawn = 10F;
    public float TimeToStart = 0f;

    void Start()
    {
        TimeToSpawn = Time.time + 10F;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time + TimeToStart >= TimeToSpawn){
            SpawnBlocks();
            TimeToSpawn = Time.time + TimeToStart + TimeBetweenBlocks;
        }  
    }
    void SpawnBlocks () 
    { 
        for(int i = 0; i < spawnPoints.Length; i++)
                {
                        int randomIndex = Random.Range(0, blockPrefabs.Length);
                    //if(randomInedex != i){
                        Vector3 pos2 = new Vector3(0, 0, 0);
                        if(randomIndex == 1) {
                            pos2 = new Vector3(0, 2.5f, 1.5f);
                        }
                        Instantiate(blockPrefabs[randomIndex], spawnPoints[i].position+pos2, Quaternion.identity);
                    //}
                    

                }
    
    }
}
