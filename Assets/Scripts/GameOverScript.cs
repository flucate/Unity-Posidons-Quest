using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        QuitGame();
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }

    public void OnClickReturnToMenu()
    {
        //load menu scene       
        SceneManager.LoadScene("menu");
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
