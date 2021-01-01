using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{

    public Color low;
    public Color high;
    public Vector3 offset;
    public bool isEnemyHealthBar = false;
    public Slider slider;

    public void SetMaxHealth(float maxhealth){
        slider.maxValue = maxhealth;
        slider.value = maxhealth;
    }
    public void SetHealth(float health){
        
        // slider.gameObject.SetActive(health < maxhealth);//show healthbar when enemy healthbar is not full
        slider.value = health;
    }
    // Update is called once per frame
    void Update()
    {
        if (isEnemyHealthBar)
        {//if this health used by enemy object
            Vector3 position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
            slider.transform.position = position;
        }
    }

    public void SetHealthBarActivated(bool condition){//display health bar depend on some condition
        slider.gameObject.SetActive(condition);
    }
}   
