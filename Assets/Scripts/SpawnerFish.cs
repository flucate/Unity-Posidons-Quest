using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFish : MonoBehaviour
{

    //Attributes
    public GameObject fish1, fish2, fish3; 
  
    private int startRange = 1; //to be used to select fish randomly
    private int endRange = 3; //to be used to select fish randomly   
    public float spawnTime = 3.0f; //to control interval between fishes creation


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddFish", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddFish()
    {
        //variable to store y position of the spawner object
        Renderer renderer = GetComponent<Renderer>();
        var posY1 = transform.position.y - renderer.bounds.size.y / 2;
        var posY2 = transform.position.y + renderer.bounds.size.y / 2;
        
        //choose a spawn point to add the fish randomly
        var spawnPoint = new Vector2(transform.position.x, Random.Range(posY1, posY2));
        var fishNumber = Random.Range(startRange, endRange + 1); //+1 to consider last number of the range in the random selection
               
        if (fishNumber == 1)
        {
            Instantiate(fish1, spawnPoint, Quaternion.identity);
        } else
            if (fishNumber == 2)
            {
                Instantiate(fish2, spawnPoint, Quaternion.identity);
            } else
                {
                    Instantiate(fish3, spawnPoint, Quaternion.identity);
                }         
               
    }
}
