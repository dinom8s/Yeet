using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boost : MonoBehaviour
{
    public float timer = 5f;
    private bool picked = false;
    private bool ItemUsed = false; 
    public float BonusSpeed;


     public void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Player")
        {
            picked = true;
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponent<MeshRenderer>());
        }
    }

    void Update()
    {
        if(picked == true){
            //Debug.Log("You Got An Item!!!");
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("You Used Boost!!!!!");
                ItemUsed = true;
                GameObject.Find("Player").GetComponent<PlayerController>().speed += BonusSpeed;
                // Debug.Log("You Used An Item!!");
            }
        }

        if(ItemUsed == true) 
        {
            timer -=Time.deltaTime;
            if (timer < 0)
            {
            Debug.Log("You Got No Item Anymore;(");
            GameObject.Find("Player").GetComponent<PlayerController>().speed -= BonusSpeed;
            Destroy(gameObject);
            }
        } 
    }
}