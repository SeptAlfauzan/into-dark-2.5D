using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Sword;
    public Animator swordAnimator;
    public Transform trailRenderer;
    public LayerMask enemyLayer;

    public Transform attackPoint;
    public float attackRange;
    void Start()
    {
        // Sword = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        Sword.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            Sword.GetComponent<SpriteRenderer>().enabled = true;
            trailRenderer.GetComponent<TrailRenderer>().enabled = true;

            Attack();
        }   
    }

    public void EnableRenderer(){
        Sword.GetComponent<SpriteRenderer>().enabled = false;
        trailRenderer.GetComponent<TrailRenderer>().enabled = false;
    }

    void Attack(){
        swordAnimator.SetTrigger("Attack");
        Collider[] enemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach (var enemy in enemies)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<Enemy>().TakeDamaged(10);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
