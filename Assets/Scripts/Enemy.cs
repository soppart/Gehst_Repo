using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    //GameObject enemy = GameObject.FindWithTag("enemy");
        public int maxhealth = 10;
    int currentHealth;
//  void Awake () {
//      otherAnimator = enemy.GetComponent<Animator>();
//  }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
    }

  public void TakeDamage(int damage)
  {
      currentHealth -= damage;
      Debug.Log("hit");

      //otherAnimator.GetComponent<Animator>.SetTrigger("hurt");
     // animator.SetTrigger("hurt");

      if(currentHealth <= 0)
      {
          Die();
      }
  }

void Die(){

    Debug.Log("enemy died");

animator.SetTrigger("death");
   // yield return new WaitForSeconds(3f);
    Destroy(gameObject);
    //otherAnimator.GetComponent<Animator>.SetTrigger("hurt");
   // animator.SetTrigger("hurt");
// GetComponent<Collider2D>().enabled = false;
// GetComponent<SpriteRenderer>().enabled = false;
//     this.enabled = false;
    
}

}
