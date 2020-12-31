using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxhealth;
    float currentHealth;
    Rigidbody rigidbody;
    public ParticleSystem walkParticle;
    public ParticleSystem landingParticle;

    public ParticleSystem dieParticle;

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
            if(!dieParticle.isEmitting){
                dieParticle.Play();//start blood particle
            }
            Die();
        }
    }

    void Die(){
        Debug.Log("die");
        Destroy(gameObject, dieParticle.main.duration);
    }

    public void RegenHealth(){
        currentHealth += 2;
    }
    

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Ground"){
            if(!walkParticle.isEmitting){
                //if particle not emmiting play particle
                walkParticle.Play();
            }
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Ground"){
            if(walkParticle.isEmitting){
                walkParticle.Stop();//stop walk particle
            }
            if(!landingParticle.isEmitting){
                landingParticle.Play();//play landing particle
            }
        }
    }

}
