using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxhealth = 100;
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
    public void tes(){
        Debug.Log("kasjdlsad");
    }
    public void TakeDamaged(int damage){
        animator.SetTrigger("Damaged");
        //Decrease player health
        currentHealth -= damage;
        //knock back player
        rigidbody.AddForce(new Vector3(rigidbody.position.x, 0, rigidbody.position.z));
        rigidbody.AddForce(Vector3.up*0.5f, ForceMode.Impulse);
        

        Debug.Log(currentHealth);
        
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
