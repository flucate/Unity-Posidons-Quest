using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    
    //Attributes
    private float speed = 2.0f; //to control fish initial speed    
    private ScoringScript scScript; //to communicate with ScoringScript
    private SubmarinoScript sbScript; //to communicate with SubmarinoScript

    public AudioClip audioFishExplosion;

    public GameObject explosionParticle;

    
    // Start is called before the first frame update
    void Start()
    {
        GetExternalComponents();
        AddSpeedToFish();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RunAudioFishExplosion()
    {
        AudioSource.PlayClipAtPoint(audioFishExplosion, transform.position);
    }


    void GetExternalComponents()
    {        
        //Find and select components from other scripts
        scScript = GameObject.Find("Scoring").GetComponent<ScoringScript>();
        sbScript = GameObject.Find("submarine").GetComponent<SubmarinoScript>();
    }

    void AddSpeedToFish()
    {
                       
        //add speed to the fish velocity on axis X
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);       
       
    }

    void RunFishExplosionAnimation()
    {
        Instantiate(explosionParticle, this.transform.position, Quaternion.identity);
        RunAudioFishExplosion();
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        

        //if fish collides with missile it is destroyed and then the missile is destroyed in sequence.
        if (other.gameObject.tag == "missileTag") 
        {   
            RunFishExplosionAnimation();         
            //if fish is killed by missile or by submarine, player loses 1 point
            if (scScript.score > 0)
            {
                scScript.score--; //add 1 point            
                scScript.sumScoreEnemy--;
            }        
           
            DestroyFish();
            Destroy(other.gameObject); //Destroy missile after collision
                                
        } 

        //if fish collides with submarine it is destroyed
        if (other.gameObject.tag == "submarineTag") 
        {    
            RunFishExplosionAnimation();      
            //if fish is killed by missile or by submarine, player loses 1 point
            if (scScript.score > 0)
            {
                scScript.score--; //add 1 point            
                scScript.sumScoreEnemy--;
            }        
           
            DestroyFish();                                              
        }           
              
    } 

    void DestroyFish()
    {
        Destroy(this.gameObject);
    }  

    //When the shark left the cam view zone it is destroyed
    void OnBecameInvisible()
    {        
        DestroyFish();
    }
}
