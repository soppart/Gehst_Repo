using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{

    //public BoxCollider2D Collide;
    
    void Start()
    {
        //Collide = GetComponent<BoxCollider2D>();
    }

   

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            //gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(gameObject);
        }
    }
}
