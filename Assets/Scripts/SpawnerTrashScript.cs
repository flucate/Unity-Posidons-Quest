using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrashScript : MonoBehaviour
{

    //Attributes
    public GameObject trash1, trash2, trash3, trash4, trash5, trash6, trash7;
    
    private int startRange = 1; //to be used to select trash randomly
    private int endRange = 7; //to be used to select trash randomly
   

    public float spawnTime = 3.0f; //to control interval between enemies creation

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddTrash", spawnTime + 2, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddTrash()
    {
        //variable to store y position of the spawner object
        Renderer renderer = GetComponent<Renderer>();
        var posY1 = transform.position.y - renderer.bounds.size.y / 2;
        var posY2 = transform.position.y + renderer.bounds.size.y / 2;
        
        //choose a spawn point to add the enemy randomly
        var spawnPoint = new Vector2(transform.position.x, Random.Range(posY1, posY2));
        var enemyNumber = Random.Range(startRange, endRange + 1); //+1 to consider last number of the range in the random selection
                       
        switch (enemyNumber)
        {
            case 1: Instantiate(trash1, spawnPoint, Quaternion.identity); break; 
            case 2: Instantiate(trash2, spawnPoint, Quaternion.identity); break;
            case 3: Instantiate(trash3, spawnPoint, Quaternion.identity); break;
            case 4: Instantiate(trash4, spawnPoint, Quaternion.identity); break;
            case 5: Instantiate(trash5, spawnPoint, Quaternion.identity); break;
            case 6: Instantiate(trash6, spawnPoint, Quaternion.identity); break;
            case 7: Instantiate(trash7, spawnPoint, Quaternion.identity); break;
        }      
                
    }
}
