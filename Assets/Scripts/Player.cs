using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxhealth = 100;
    float currentHealth;
    new Rigidbody rigidbody;
    public HealthBarBehaviour healthBar;

    public Animator animator;

    public AudioSource bgMusic;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        currentHealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
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
        //set healthbar value
        healthBar.SetHealth(currentHealth);
        //knock back player
        // rigidbody.AddForce(new Vector3(rigidbody.position.x, 0, rigidbody.position.z));
        rigidbody.AddForce(Vector3.up*2f, ForceMode.Impulse);
        
        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("die");
        bgMusic.Stop();
        Destroy(gameObject);
        GameObject.Find("TransitionScreen").transform.GetComponent<GameManager>().GameOver();//call gameover fucntion from gamemanager script
    }

}
