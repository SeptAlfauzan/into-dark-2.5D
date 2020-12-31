using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody playerRb;
    public Vector3 movement;

    public GameObject playerSprite;

    GameObject playerpointLight;
    bool isFlipped = false; 

    bool IsGrounded = false;//boolean when player collide with ground
    Vector3 jumpVector = new Vector3(0,1,0);
    Vector3 newPlayerLocalScale;//reference for new player localscale
    public float jumpForce;
    Animator animator;//animator for player
    public Animator camAnim;

    public ParticleSystem landingParticle;
    public ParticleSystem runParticle;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        newPlayerLocalScale = new Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        

        RotateDirection(movement.x);
        movement*= speed;
        //intantiate run animation
        RunAnimate(movement.x, movement.z);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            IsGrounded = false;//change isGrounded value to false then jump
            Jump();
        }
    }

    void RunAnimate(float movementX, float movementZ){
        int speed = 0;//speed variable to instantiate run animation
        var movementXAbs = Mathf.Abs(movementX);//get absolute value from x axis
        var movementZAbs = Mathf.Abs(movementZ);//get absolute value from z axis
        speed = movementXAbs > 0 || movementZAbs > 0? 1: -1; // if movement X or Z abs greeater than 0, then assigned 1 to speed variable, and otherwise assign -
        animator.SetFloat("Run",speed);
    }

    private void FixedUpdate() {
        playerRb.velocity = new Vector3(movement.x, playerRb.velocity.y, movement.z);
    }
    private void RotateDirection(float xAxis) {
        if (xAxis < 0 && !isFlipped)
        {//change variable reference value base on player x axis value(right or left move)
            isFlipped = true;
            newPlayerLocalScale = new Vector3(-1,1,1); 
        }
        if(xAxis > 0 && isFlipped){
            isFlipped = false;
            newPlayerLocalScale = new Vector3(1,1,1); 
        }
        FlipPlayerObject(newPlayerLocalScale);
    }


    private void FlipPlayerObject(Vector3 newLocalScale){
        playerSprite.transform.localScale = newLocalScale;
    }


    private void OnCollisionStay(Collision collider) {
        if (collider.gameObject.tag == "Ground")
        {
            if(!runParticle.isEmitting){//if run particle is not emmiting play particle
                runParticle.Play();
            }
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collider) {
        if (collider.gameObject.tag == "Ground")
        {//stop particle when player jump on ground
            if(runParticle.isEmitting){//if run particle is emmiting stop particle
                runParticle.Stop();
            }
            IsGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.tag == "Ground")
        {
            if (!landingParticle.isEmitting)//check wheter landing particle is not emiting 
            {
                //camera shake effect
                Camera.main.GetComponent<FollowPlayer>().Shake(1f, 10);
                landingParticle.Play();//play landing particle
            }
        }
    }



    private void Jump(){
        playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
    }
    


}
