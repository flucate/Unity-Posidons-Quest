using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    //Attributes
    public AudioClip audioMenuOption;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        QuitGame();
    }    

    void RunAudioOnClickMenuOption()
    {
        AudioSource.PlayClipAtPoint(audioMenuOption, transform.position);
    }

    public void OnClickStartGame()
    {    
        RunAudioOnClickMenuOption();
        //load gameplay scene
        Time.timeScale = 1; //unpause game in case it was paused before escape
        SceneManager.LoadScene("fase1");
    }

    public void OnClickCredits()
    {      
        RunAudioOnClickMenuOption();  
        //load credits scene        
        SceneManager.LoadScene("credits");
    }

    public void OnClickInstructions()
    {   
        RunAudioOnClickMenuOption();     
        //load credits scene        
        SceneManager.LoadScene("instructions");
    }

    public void OnClickExitGame()
    {  
        RunAudioOnClickMenuOption();
        Application.Quit();
    }

    void QuitGame()
    {
        //quit the game when escape key is pressed but only on executable file
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
