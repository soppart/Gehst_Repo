using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
   public Animator animator;

   public Transform attackPoint;
   public LayerMask enemyLayers;
   public float attackRange = 0.5f;
   
   public int attackDamage = 5;

    //public GameObject circusEnemy;
    //public Rigidbody2D Rigid;
    //public float knockback = 2.0f;

    //void Start()
    //{
    //   Rigid = circusEnemy.GetComponent<Rigidbody2D>();
    //}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            ////knockback
            //Rigid.AddForce(transform.forward * knockback);
        }
    }

void OnDrawGizmosSelected(){

if(attackPoint == null)
return;
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}

}
