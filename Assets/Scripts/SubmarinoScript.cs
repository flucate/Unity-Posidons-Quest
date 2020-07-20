using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmarinoScript : MonoBehaviour
{

    //Attributes
    public float speed = 5;
    public GameObject missile, missileLeft; //will receive missiles prefabs
    public GameObject explosionParticle; //will receive Submarine Explosion Particle
    
    public Text livesUI; //will receive UI.Lives
    public int lives = 3;

    public bool facingRight;

    public AudioClip audioSubmarineDamage, audioSubmarineExplosion; //will receive audios 
    
    private ScoringScript scScript; //to communicate with ScoringScript   


    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        ReturnToMenu();
        MoveSubmarine();        
        ShootMissile();
        PreventSubmarineFromLeavingScreen();       
        UpdateLives();        
    }

    void RunSubmarineExplosionAnimation()
    {
        RunAudioSubmarineExplosion();
        Instantiate(explosionParticle, this.transform.position, Quaternion.identity);        
    }

    public void FlipPlayer(float direction)
    {
        if ((direction > 0 && !facingRight) || (direction < 0 && facingRight))
        {
            facingRight = !facingRight;            
            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1; 
            transform.localScale = playerScale;
        }
    }

    public void AddLife()
    {               
        lives++;               
    }

    void OnTriggerEnter2D (Collider2D other)
    {       
        if(other.gameObject.tag == "enemyTag")
        {                        
            lives--; //one life is lost when submarine collides with enemy      
                     
            //after 3 collisions, submarine is destroyed
            if(lives == 0)
            {          
                RunSubmarineExplosionAnimation();                                                     
                UpdateLives();                             
                                     
                //Load game over scene
                Invoke("LoadGameOver", 1.5f);                
            }
            else
            {
                if (lives > 0)
                {
                    RunAudioSubmarineDamage();
                }
            }            
        }
    }

    void LoadGameOver()
    {
        
        //load menu scene       
        SceneManager.LoadScene("gameOver");

        DestroySubmarine();
    }

    void RunAudioSubmarineExplosion()
    {
        AudioSource.PlayClipAtPoint(audioSubmarineExplosion, transform.position);
    }

    void RunAudioSubmarineDamage()
    {
        AudioSource.PlayClipAtPoint(audioSubmarineDamage, transform.position);
    }

    void MoveSubmarine()
    {
        //Move submarine horizontally using narrow keys or A and D keys
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        FlipPlayer(moveX);

        //Move submarine horizontally using narrow keys or W and S keys
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //Apply changes to the submarine
        transform.Translate(moveX, moveY, 0);
    }

    void ShootMissile()
    {
        //if space bar is pressed, new missile is istantiated
        if (Input.GetKeyDown("space"))
        {
            if (facingRight == true)
            {
                //+0.95f and -0.1f are coordinates for x and y axis to align missile to submarine's front
                Instantiate(missile, new Vector2(transform.position.x + 0.95f, transform.position.y -0.1f), Quaternion.identity);
            }
            else
            {
                //-0.95f and -0.1f are coordinates for x and y axis to align missile to submarine's front
                Instantiate(missileLeft, new Vector2(transform.position.x - 0.95f, transform.position.y -0.1f), Quaternion.identity);
            }
        }
    }

    void ReturnToMenu()
    {
        //quit the game when escape key is pressed but only on executable file
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void PreventSubmarineFromLeavingScreen()
    {
        
        //prevent submarine from leaving cam X limits
        if (transform.position.x > 5.56f || transform.position.x < -5.56f)
        {
            float posX = Mathf.Clamp(transform.position.x, -5.56f, 5.56f);
            transform.position = new Vector2(posX, transform.position.y);
        }

        //prevent submarine from leaving cam Y limits
        if (transform.position.y > 3.0f || transform.position.y < -3.0f)
        {
            float posY = Mathf.Clamp(transform.position.y, -3.0f, 3.0f);
            transform.position = new Vector2(transform.position.x, posY);
        }
    }

    public void UpdateLives()
    {      
        livesUI.text = "Lives: " + lives;
    }

    public void DestroySubmarine()
    {
        Destroy(this.gameObject);
    }
}
