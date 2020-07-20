using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemyScript : MonoBehaviour
{

    //Attributes
    public GameObject enemy1, enemy2, enemy3; 
  
    private int startRange = 1; //to be used to select enemy randomly
    private int endRange = 3; //to be used to select enemy randomly   

    public float spawnTime = 3.0f; //to control interval between enemies creation



    // Start is called before the first frame update
    void Start()
    {    
        
        InvokeRepeating("AddEnemy", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   


    void AddEnemy()
    {
        //variable to store y position of the spawner object
        Renderer renderer = GetComponent<Renderer>();
        var posY1 = transform.position.y - renderer.bounds.size.y / 2;
        var posY2 = transform.position.y + renderer.bounds.size.y / 2;
        
        //choose a spawn point to add the enemy randomly
        var spawnPoint = new Vector2(transform.position.x, Random.Range(posY1, posY2));
        var enemyNumber = Random.Range(startRange, endRange + 1); //+1 to consider last number of the range in the random selection
               
        if (enemyNumber == 1)
        {
            Instantiate(enemy1, spawnPoint, Quaternion.identity);
        } else
            if (enemyNumber == 2)
            {
                Instantiate(enemy2, spawnPoint, Quaternion.identity);
            } else
                {
                    Instantiate(enemy3, spawnPoint, Quaternion.identity);
                }         
               
    }
}
