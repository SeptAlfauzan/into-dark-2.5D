using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    Transform PlayerObject;
    float distanceToPlayer;
    Rigidbody rigidbody;
    Animator animator;

    float enemyAttackRange;
    public float enemyChaseRange = 2.4f;
    public float moveSpeed = 1f;
    bool isFlipped = false;
    Vector3 newLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        newLocalScale = GetComponent<Transform>().localScale;
        enemyAttackRange = GetComponent<EnemyAttack>().attackRange;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        PlayerObject = GameObject.Find("PlayerObject").transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(PlayerObject.transform.position, transform.position);//get distance from player to enemy
     
        // Debug.Log("distance between "+transform.name+" and player is"+distanceToPlayer);
        if(distanceToPlayer < enemyChaseRange){

            ChasePlayer();
            if(distanceToPlayer < enemyAttackRange){
                StopChase();
                animator.SetTrigger("Attack");
                GetComponent<EnemyAttack>().Attack();
            }        
        }else{
            StopChase();
            GetComponent<Enemy>().RegenHealth();//regen health if player to far from enemy
        }
    }
    private void FlipPlayerObject(Vector3 newLocalScale){
       transform.localScale = newLocalScale;
    }

    void ChasePlayer(){
        // Debug.Log("im chasing you");
        var newpos = Vector3.MoveTowards(rigidbody.position, PlayerObject.position, moveSpeed*Time.deltaTime);
        
        // change enemy faced
        if (PlayerObject.transform.position.x > transform.position.x && !isFlipped){
            isFlipped = true;
            newLocalScale = new Vector3(-newLocalScale.x,newLocalScale.y,newLocalScale.z); 
        }
        if(PlayerObject.transform.position.x < transform.position.x && isFlipped){
            isFlipped = false;
            newLocalScale = new Vector3(Mathf.Abs(newLocalScale.x),newLocalScale.y,newLocalScale.z); 
        }
        FlipPlayerObject(newLocalScale);//asign new local scale

        //start running animation
        animator.SetFloat("Running", 1);
        rigidbody.MovePosition(newpos);
    }

    void StopChase(){
        rigidbody.velocity = Vector3.zero;
        //stop running animation
        animator.SetFloat("Running", -1);
    }
}
