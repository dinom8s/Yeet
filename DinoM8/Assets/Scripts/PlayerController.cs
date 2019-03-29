using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public float speed = 50f;
    public CharacterController controller;

    public float gravityScale;
    private Vector3 moveDirection;
    private bool isMoving = true;
    public float acceleration = 1.2f;
    public GameObject spawnpoint;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = 20f;
        speed = 20f;
        gravityScale = 0.1f;
        jumpForce = 25f;
    }

    void Update()
    {
        if(isMoving == true) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, speed);
            //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

            speed += Time.deltaTime * acceleration;

            if(Input.GetKeyDown(KeyCode.LeftShift)) {
                gravityScale = 0.5F;
            }
            if(Input.GetKeyUp(KeyCode.LeftShift)){
                gravityScale = 0.1F;
            }


            if (controller.isGrounded)
            {


                if(Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = jumpForce;
                } 
            } 


            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
            controller.Move(moveDirection * Time.deltaTime);

            if(Input.GetKeyDown(KeyCode.Space)){
            // transform.position = new Vector3(0, 100, 0);
                //it is being called everytime our capsule hits somthing 
            } 
        }
    }
void OnControllerColliderHit(ControllerColliderHit hit)
           {
            if (hit.gameObject.tag == "Blocker") 
            {
                Death();
                /*moveSpeed = 0f;
                speed = 0f;
                jumpForce = 0f; */
                }

            }
            
           private void Death()
            {
               transform.position = spawnpoint.transform.position;
               
               moveSpeed = 0f;
               speed = 0f;
               jumpForce = 0f;
               acceleration = 0f;
            }
}