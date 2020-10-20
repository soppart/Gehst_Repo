using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemy1 : MonoBehaviour
{

    public GameObject enemy1;
    
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
      
    }

    private void spawnEnemy()
    {
        GameObject eRight = Instantiate(enemy1) as GameObject;
        eRight.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
        
        GameObject eLeft = Instantiate(enemy1) as GameObject;
        eLeft.transform.position = new Vector2(screenBounds.x * -1, Random.Range(-screenBounds.y, screenBounds.y));
        
        //GameObject eUp = Instantiate(enemy1) as GameObject;
        //eUp.transform.position = new Vector2(screenBounds.y * 1, Random.Range(-screenBounds.x, screenBounds.x));
    }

    IEnumerator enemyWave()
    { while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            enemy1.layer = LayerMask.NameToLayer("ground");
        }
       
    }

}

