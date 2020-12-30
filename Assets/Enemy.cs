﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxhealth;
    float currentHealth;
    Rigidbody rigidbody;

    public Animator animator;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        currentHealth = maxhealth;
    }

    private void FixedUpdate() {
        if (transform.position.y < -3)
        {
            Die();
        }
    }

    public void TakeDamaged(int damage){
        animator.SetTrigger("Attacked");
        //Decrease enemy health
        currentHealth -= damage;
        //knock back enemy
        rigidbody.AddForce(new Vector3(rigidbody.position.x, 0, rigidbody.position.z));
        rigidbody.AddForce(Vector3.up*1f, ForceMode.Impulse);
        
        
        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("die");
        Destroy(gameObject);
    }

    public void RegenHealth(){
        currentHealth += 2;
    }
}
