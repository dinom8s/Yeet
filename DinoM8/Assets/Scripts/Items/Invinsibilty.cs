using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinsibilty : MonoBehaviour
{
    public float timer = 2f;
    private bool picked = false;
    private bool ItemUsed = false;

    public void OnTriggerEnter(Collider other)
    { 
        picked = true;
        if(other.gameObject.tag == "Player")
        {
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponent<MeshRenderer>());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(picked == true){
           //Debug.Log("You Got An Item!!!");
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("You Used Invinsibility!!!!!");
                ItemUsed = true;
                GameObject.FindWithTag("Blocker").GetComponent<BoxCollider>().enabled = false;
               // Debug.Log("You Used An Item!!");
            }
        }

        if(ItemUsed == true) 
        {

            timer -=Time.deltaTime;
            if (timer < 0)
            {
            Debug.Log("You Got No Item Anymore;(");
            GameObject.Find("Cube").GetComponent<BoxCollider>().enabled = true;
            Destroy(gameObject);
            }
        } 
    }
}