using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringScript : MonoBehaviour
{

    //Attributes

    public Text scoreUI, recordUI; 
    
    public int score = 0;    

    public int sumScoreEnemy = 0, sumScoreTrash = 0;       
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {
        UpdateScore();               
        UpdateRecord();        
    }
  
  public void ResetSumScoreFromEnemyAndTrash()
    {
        sumScoreEnemy = 0;
        sumScoreTrash = 0;
    } 

    void UpdateScore()
    {
        
        scoreUI.text = "Score: " + score;
    }

    void UpdateRecord()
    {
        if (score > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", score);
        }

        recordUI.text = "Record: " + PlayerPrefs.GetInt("Record");
    }
}
