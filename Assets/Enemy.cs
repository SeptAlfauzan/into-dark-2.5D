using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxhealth;
    float currentHealth;

    public Animator animator;
    void Start()
    {
        currentHealth = maxhealth;
    }

    public void TakeDamaged(int damage){
        animator.SetTrigger("Attacked");
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("die");
        Destroy(gameObject);
    }
}
