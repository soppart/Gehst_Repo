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

    //public GameObject circusEnemy;
    public Rigidbody2D Rigid;
    public float knockback = 100.0f;
    Vector2 m_NewForce;
    public bool gotHit = false;
    private int frames = 0;
    private bool countFrames = false;


    void Start()
    {
        //damage
        currentHealth = maxhealth;

        //knockback
        Rigid = GetComponent<Rigidbody2D>();
 
        //transform.position = new Vector2(-2.0f, 0.0f);
        //m_NewForce = new Vector2(-5.0f, 1.0f);
    }

  void FixedUpdate()
    {
        if (countFrames)
        {
            frames++;
        }

       if (gotHit)
        {
            countFrames = true;
            //disable aggro
            gameObject.GetComponent<enemyAggro>().enabled = false;
            AddForce();
            gotHit = false;
            
        }
        if (frames == 200)
        {
            //enable aggro
            gameObject.GetComponent<enemyAggro>().enabled = true;
            countFrames = false;
            frames = 0;
        }


    }

    public void TakeDamage(int damage)
  {
        //damage

      currentHealth -= damage;
      Debug.Log("hit");
    animator.SetTrigger("hurt");
        //otherAnimator.GetComponent<Animator>.SetTrigger("hurt");
        // animator.SetTrigger("hurt");

        //knockback
        gotHit = true;
        //AddForce();
       // Update();

        if (currentHealth <= 0)
      {
          Die();
      }
  }

    void AddForce()
    {
        m_NewForce = new Vector2(16.0f, 5.0f);
        Rigid.AddForce(m_NewForce, ForceMode2D.Impulse);
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
