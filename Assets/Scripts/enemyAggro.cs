using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAggro : MonoBehaviour
{
    [SerializeField]
    
  Animator enemyAnim;
  [SerializeField]
    Transform player;

    [SerializeField]
    float aggroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
       // enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float distToPlayer = Vector2.Distance(transform.position, player.position);
        print("distToPlayer:" + distToPlayer);

        if(distToPlayer < aggroRange)
        {
                chasePlayer();
                enemyAnim.SetBool("isWalking", true);
        }
        else
        {
                StopChasingPlayer();
                enemyAnim.SetBool("isWalking", false);
        }


    }

    private void chasePlayer()
    {

    if(transform.position.x < player.position.x) //move right
    {
        rb2d.velocity = new Vector2(moveSpeed, 0);
       
    }
    else  if(transform.position.x > player.position.x)
    {
        rb2d.velocity = new Vector2(-moveSpeed, 0); //move left
       
    }

        if ((rb2d.velocity[0] > 2 && transform.localScale.x > 0) || (rb2d.velocity[0] < -2 && transform.localScale.x < 0))
        {
            transform.localScale *= new Vector2(-1, 1);
        }


    }

    private void StopChasingPlayer()
    {

    }

}


