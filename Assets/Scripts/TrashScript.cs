using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashScript : MonoBehaviour
{

    //Attributes

    public float speed = 2.0f; //to control initial trash speed
    private ScoringScript scScript; // to communicate with spaceshipScript
    private SubmarinoScript sbScript; //to communicate with SubmarinoScript

    public AudioClip audioTrashCollection, audioTrashExplosion;

    public GameObject explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {         
        GetExternalComponents();
        AddSpeedToTrash();            
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    void RunTrashExplosionAnimation()
    {
        Instantiate(explosionParticle, this.transform.position, Quaternion.identity);
        RunAudioTrashExplosion();
    }

    void DestroyTrash()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D (Collider2D other){
        //if trash collides with submarine it is destroyed and player wins +3 points
        if(other.gameObject.tag == "submarineTag"){
            RunAudioTrashCollection();
            DestroyTrash();                   
            scScript.score += 3;
            scScript.sumScoreTrash += 3;            
        }

        //if trash is destroyed by missile player wins only +2 points
        if(other.gameObject.tag == "missileTag"){
            RunTrashExplosionAnimation();
            DestroyTrash();
            Destroy(other.gameObject);                   
            scScript.score += 2;            
            scScript.sumScoreTrash += 2;
        }       
      
        //if sum of points is equal or greater than 150 points, player wins +1 life
        if ((scScript.sumScoreTrash + scScript.sumScoreEnemy) >= 150)
        {
            sbScript.AddLife();                
            sbScript.UpdateLives();  
            scScript.ResetSumScoreFromEnemyAndTrash();                  
        }
    }

    //When the trash left the cam view zone it is destroyed
    void OnBecameInvisible()
    {
        DestroyTrash();
    }

    //Get components from external objects
    void GetExternalComponents()
    {        
        //Find objects and get components from them
        scScript = GameObject.Find("Scoring").GetComponent<ScoringScript>();
        sbScript = GameObject.Find("submarine").GetComponent<SubmarinoScript>();
    }

    void AddSpeedToTrash()
    {
        //add speed to the trash velocity
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0); 
    }

    void RunAudioTrashCollection()
    {
        AudioSource.PlayClipAtPoint(audioTrashCollection, transform.position);
    }

    void RunAudioTrashExplosion()
    {
        AudioSource.PlayClipAtPoint(audioTrashExplosion, transform.position);
    }
}
