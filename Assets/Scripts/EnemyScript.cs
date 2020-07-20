using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    //Attributes

    private float speed = 2.0f; //to control enemy initial speed    
    private ScoringScript scScript; //to communicate with ScoringScript
    private SubmarinoScript sbScript; //to communicate with SubmarinoScript 

    public AudioClip audioEnemyExplosion;

    public GameObject explosionParticle;
   
  
    // Start is called before the first frame update
    void Start()
    {          
             
        GetExternalComponents();
        AddSpeedToEnemy();      
                   
    }

    // Update is called once per frame
    void Update()
    {             
        
    }  

    

    void RunAudioEnemyExplosion()
    {
        AudioSource.PlayClipAtPoint(audioEnemyExplosion, transform.position);
    }

    //Get components from external objects
    void GetExternalComponents()
    {        
        //Find and select components from other scripts
        scScript = GameObject.Find("Scoring").GetComponent<ScoringScript>();
        sbScript = GameObject.Find("submarine").GetComponent<SubmarinoScript>();
    }

    void AddSpeedToEnemy()
    {
        //on each 100 points and if enemy speed < 20.0f, speed++
        if (((scScript.sumScoreEnemy + scScript.sumScoreTrash) >= 100) && (speed <= 10.0f))
        {                                    
            speed++;                               
        }
                
        //add speed to the enemy velocity on axis X
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0); 

    }

    void RunEnemyExplosionAnimation()
    {
        Instantiate(explosionParticle, this.transform.position, Quaternion.identity);
        RunAudioEnemyExplosion();
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        //if enemy collides with missile it is destroyed and then the missile is destroyed in sequence.
        if (other.gameObject.tag == "missileTag") 
        {     
            RunEnemyExplosionAnimation();        
            scScript.score++; //add 1 point            
            scScript.sumScoreEnemy++;
           
            //if sum of points is equal or greater than 150 points, player wins +1 life
            if ((scScript.sumScoreEnemy + scScript.sumScoreTrash) >= 150)
            {                             
                sbScript.AddLife();                
                sbScript.UpdateLives();
                scScript.ResetSumScoreFromEnemyAndTrash();                
            }               

            DestroyEnemy();
            Destroy(other.gameObject); //Destroy missile after collision                                  
        }           
    } 

    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }  

    //When the shark left the cam view zone it is destroyed
    void OnBecameInvisible()
    {
        
        DestroyEnemy();
    }

}
