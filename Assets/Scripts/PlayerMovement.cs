using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody playerRb;
    public Vector3 movement;

    GameObject playerSprite;

    GameObject playerpointLight;
    bool isRotated = false; 
    GameObject spriteSword; 

    bool IsGrounded = false;//boolean when player collide with ground
    Vector3 jumpVector = new Vector3(0,1,0);
    public float jumpForce;
    // Quaternion rotateOffset = new Quaternion(70f, 180f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerSprite = gameObject.transform.GetChild(0).gameObject;
        spriteSword = playerSprite.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        

        RotateDirection(movement.x);
        movement*= speed;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            IsGrounded = false;
            Jump();
        }
        Debug.Log(IsGrounded);
    }

    private void FixedUpdate() {
        playerRb.velocity = new Vector3(movement.x, playerRb.velocity.y, movement.z);
    }

    private void RotateDirection(float xAxis) {
        var swordLocalPos = spriteSword.transform.localPosition;
        if (xAxis < 0)
        {
            playerSprite.transform.GetComponent<SpriteRenderer>().flipX = true;
            spriteSword.transform.GetComponent<SpriteRenderer>().flipX = true;
            spriteSword.transform.localPosition = new Vector3(-0.3f,swordLocalPos.y, swordLocalPos.z); 
    
        }else{
            playerSprite.transform.GetComponent<SpriteRenderer>().flipX = false;
            spriteSword.transform.GetComponent<SpriteRenderer>().flipX = false;
            spriteSword.transform.localPosition = new Vector3(0.3f,swordLocalPos.y, swordLocalPos.z); 

        }
    }

    private void OnCollisionStay(Collision collider) {
        if (collider.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    private void Jump(){
        playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
    }
    


}
