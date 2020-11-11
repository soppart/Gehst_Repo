using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    //Renderer rend;
    //Color c;

    private int health = 5;

    private int maxHealth = 5;

    public GameObject healthBar;

    public GameObject heartPrefab;



    void Start()
    {
        //rend = GetComponent<Renderer>();
        //c = rend.material.color;

        for (int i = 0; i < maxHealth; i++)
        {
            AddLifeBar();
        }
        UpdateLifeBar();
    }

    void AddLifeBar()
    {
        Instantiate(heartPrefab, healthBar.transform);
    }


    void UpdateLifeBar()
    {
        Image[] img_ary = healthBar.GetComponentsInChildren<Image>();
        for(int i = 1; i < img_ary.Length; i++)
        {
            if(i<= health)
            {
                //c.a = 1f;
                //rend.material.color = c;
                img_ary[i].color = new Color(.95f,.86f, .73f,1f);
                
            }
            else
            {
                //c.a = 0.3f;
                //rend.material.color = c;
                //Destroy(img_ary[i]);
                img_ary[i].color = new Color(0,0,0,0.4f);
            }
        }
    }

    public void AddHealth()
    {
        if (health < maxHealth)
        {
            health++;
            UpdateLifeBar();
           
        }
    }

    public void RemoveHealth(int amount)
    {
        health -= amount;
        if (health < 1)
        {
            print("die");
        }
        UpdateLifeBar();
    }

    public void AddMaxHealth()
    {
        maxHealth++;
        AddLifeBar();
    }

}
