using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
        public int maxhealth = 10;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
    }

  public void TakeDamage(int damage)
  {
      currentHealth -= damage;

      animator.SetTrigger("hurt");

      if(currentHealth <= 0)
      {
          Die();
      }
  }

void Die(){

    Debug.Log("enemy died");

    animator.SetTrigger("hurt");
GetComponent<Collider2D>().enabled = false;
GetComponent<SpriteRenderer>().enabled = false;
    this.enabled = false;
    
}

}
