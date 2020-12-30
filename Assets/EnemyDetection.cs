using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    Transform PlayerObject;
    float distanceToPlayer;
    Rigidbody rigidbody;
    Animator animator;
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        PlayerObject = GameObject.Find("PlayerObject").transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(PlayerObject.transform.position, transform.position);//get distance from player to enemy
        Debug.Log(distanceToPlayer);
        // Debug.Log("distance between "+transform.name+" and player is"+distanceToPlayer);
        if(distanceToPlayer < 2.2f){

            ChasePlayer();
            if(distanceToPlayer <= 0){
                GetComponent<EnemyAttack>().Attack();
                // StopChase();
            }        
        }else{
            StopChase();
            GetComponent<Enemy>().RegenHealth();//regen health if player to far from enemy
        }
    }

    void ChasePlayer(){
        // Debug.Log("im chasing you");
        var newpos = Vector3.MoveTowards(rigidbody.position, PlayerObject.position, moveSpeed*Time.deltaTime);
        
        //start running animation
        animator.SetTrigger("Running");
        rigidbody.MovePosition(newpos);
    }

    void StopChase(){
        rigidbody.velocity = Vector3.zero;
    }
}
