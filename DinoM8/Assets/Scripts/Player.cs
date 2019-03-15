using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    /// Kan vi se denna=
    public Rigidbody rb;
    public float moveSpeed;
    public float jumpPower;
    public float verticalSpeed = 2.0F;
    public float horizontalSpeed = 2.0F;
    public float fallMultiplier = 2.5F;
    public float jumpVelocity;
    public float lowJumpMultiplier = 2.0F;
    public float downSpeed;
    public float characterSize0;
    public float characterSize1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 20F;
        jumpPower = 5000F;
        downSpeed = -250F;
        characterSize0 = (0, 1, -1);
        characterSize1 = (0, -1, 1);
    }

    // Update is called once per frame
    void update()
    { 
        
    }
    void FixedUpdate()
    {  
        
         if(Input.GetKeyDown("s")){
             rb.AddForce(0, downSpeed, 0);
             transform.localScale += new Vector3(0, -1, 1);
         }
         if(Input.GetKeyUp("s")){
             transform.localScale += new Vector3(0, 1, -1);
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