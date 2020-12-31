using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMoving : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    // private void OnTriggerEnter(Collider collider) {
    //     if (collider.gameObject.tag == "Player"){
    //         //when player collide with grass trigger "forced" grass animation
    //         animator.SetTrigger("TouchedPlayer"); 
    //     }
    // }
}
