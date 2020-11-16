using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glitchMonsterEnemy : MonoBehaviour
{
    public Animator animator;
    //GameObject enemy = GameObject.FindWithTag("enemy");
        public int maxhealth = 10;
    int currentHealth;
   

    //public GameObject circusEnemy;
    public Rigidbody2D Rigid;
    public BoxCollider2D Collide;
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
        Collide = GetComponent<BoxCollider2D>();
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
        

        //knockback
        gotHit = true;
        //AddForce();
       // Update();

        if (currentHealth <= 0)
      {
            StartCoroutine("Death");
          //Die();
      }
  }

    void AddForce()
    {
        m_NewForce = new Vector2(16.0f, 5.0f);
        Rigid.AddForce(m_NewForce, ForceMode2D.Impulse);
    }


    IEnumerator Death()
    {
        Debug.Log("enemy died");
        gameObject.GetComponent<enemyAggro>().enabled = false;
        animator.SetBool("isDead", true);
        // yield return new WaitForSeconds(1.7f);
        yield return new WaitForSeconds(.60f);
        
        Destroy(gameObject);
    }
    //void Die(){

    ////enemyAnim.SetBool("isDead", true);
    //    Debug.Log("enemy died");

    //animator.SetTrigger("death");

    //    Destroy(gameObject);


}

