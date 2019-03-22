using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    /// Kan vi se denna=
    public Rigidbody rb;
    public float moveSpeed;
    public float jumpPower;
    public float downSpeed;
    public float CharacterSize0;
    public float CharacterSize1;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 20F;
        jumpPower = 5000F;
        downSpeed = -250F;
        CharacterSize0 = 0;
        CharacterSize1 = 0;
    }
    // Update is called once per frame
    void update()
    { 
                
    }
    void FixedUpdate()
    {  
        //////////////////////////////////////////
        //                                      //
        //               Movement               //
        //                                      //
        //////////////////////////////////////////
          
         if(Input.GetKeyDown("s")){
             rb.AddForce(0, downSpeed, 0);
             transform.localScale += new Vector3(0, CharacterSize1 - 1, CharacterSize0 + 1);
         }
         if(Input.GetKeyUp("s")){
             transform.localScale += new Vector3(0, CharacterSize1 + 1, CharacterSize0 - 1);
                
         }
         if(Input.GetKeyUp("space")){
             rb.AddForce(0, downSpeed, 0);
         }
         transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0,0);
         rb.AddForce(0, 0, moveSpeed);
         RaycastHit hit = new RaycastHit();
         if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
             float distanceToGround = hit.distance;
                    if(distanceToGround < transform.localScale.y + 0.0001){
                     if(Input.GetAxis("Jump") > 0) {
                        rb.AddForce(0, jumpPower * Time.deltaTime, 0);
                 }
            }
        }



    }   
}