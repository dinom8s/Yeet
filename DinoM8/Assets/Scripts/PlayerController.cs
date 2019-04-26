using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public float speed = 50f;
    public CharacterController controller;
    public bool startTimer = false;

    public float gravityScale;
    private Vector3 moveDirection;
    private bool isMoving = true;
    public float acceleration = 1.5f;
    public BlockSpawner bs;
    public SpawnerScript ss;
    private NetworkManager net;

    void Start()
    {
        Time.timeScale = 0;
        controller = GetComponent<CharacterController>();
        moveSpeed = 20f;
        speed = 20f;
        gravityScale = 0.1f;
        jumpForce = 25f;
    }

    void Update()
    {

        if(Input.anyKeyDown)
        {
            Time.timeScale = 1;
            GameObject.Find("Score").GetComponent<Score>().timer = true;
        }
        
        //Debug.Log(Time.timeScale);
    
        if(isMoving == true) {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, speed);

                speed += Time.deltaTime * acceleration;

                if(Input.GetKeyDown(KeyCode.S)) {
                    gravityScale = 0.5F;
                }
                if(Input.GetKeyUp(KeyCode.S)){
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

        }
    }
void OnControllerColliderHit(ControllerColliderHit hit)
           {
                if (hit.gameObject.tag == "Blocker") 
                {
                    Death();   
                }
                       
                if (hit.gameObject.tag == "Finish") 
                {
                    moveSpeed = 0f;
                    speed = 0f;
                    jumpForce = 0f; 
                    GameObject.Find("Booster").GetComponent<Boost>().BonusSpeed = 0;
                    GameObject.Find("ScoreText").GetComponent<Score>().scoreValue = 0;

                }
            } 
    private void Death()
            {
                 Application.LoadLevel(Application.loadedLevel);
//                 Debug.Log(bs.TimeToStart);
                 bs.TimeToStart = Time.time;
                 ss.TimeToStart = Time.time;
                 Time.timeScale = 0;                        
                 GameObject.Find("Score").GetComponent<Score>().timer = false;
                //transform.position = GameObject.Find("spawnpoint").transform.position;        
            }
            

}