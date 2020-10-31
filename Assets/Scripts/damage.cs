using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public int health = 5;
    

    void OnTriggerEnter2D(){
        Debug.Log ("Trigger!");
        health--;
    }

    void Update() {
        if(health <= 0) {
            Die();
        }

    }


   void Die(){
       Destroy(gameObject);
        
    }
}