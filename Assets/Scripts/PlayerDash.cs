using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody playerRb;
    Vector3 movementDir;

    public float dashTime;
    Vector3 movementPlayer; 
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        movementDir = GetComponent<PlayerMovement>().movement;
        if(Input.GetKeyDown(KeyCode.Q)){
            // playerRb.AddForce(movementDir*100f, ForceMode.Impulse);
            Dash(movementDir);
        }
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            Debug.Log(dashTime);
        }
    }

    IEnumerator Dash(Vector3 direction){
            Debug.Log("dasd");
        Debug.Log(movementDir);
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            playerRb.AddForce(direction*10f, ForceMode.Impulse);
            yield return null;
        }
    }
}
