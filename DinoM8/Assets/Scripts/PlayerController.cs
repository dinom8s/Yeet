using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    public float gravityScale;
    private Vector3 moveDirection;
    private bool isMoving = true;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = 20F;
        jumpForce = 25F;
        gravityScale = 0.1F;

    }

    void Update()
    {
        if(isMoving == true) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);


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
               if(hit.point.z > transform.position.z + controller.radius)
               {
                   Death();
               }
           }
           private void Death()
           {
                transform.position = new Vector3(0,2,-51);
               // isMoving = false;
                //moveDirection.enabled=false;
           }
}