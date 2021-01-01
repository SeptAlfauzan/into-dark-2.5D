using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask playerLayer;
    new Rigidbody rigidbody;
    public AnimationClip attackAnimation;

    float nextAttackTime = 0f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Attack(){
        rigidbody.velocity = Vector3.zero;//stop enemy moving
        Collider[] players = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);
         if (Time.time >= nextAttackTime)
        {    
            // call attack animation
            animator.SetTrigger("Attack");
            Debug.Log("enemy attack");

            foreach (var player in players)
            {
                player.GetComponentInParent<Player>().TakeDamaged(1);
            }     
            nextAttackTime = Time.time + attackAnimation.length;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
