using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseScript : MonoBehaviour
{
    //Attributes
    bool isPause;

    public AudioClip audioPause;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            RunAudioPause();
            
            isPause = !isPause;

            if (isPause)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }  
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void UnPause()
    {
        Time.timeScale = 1;
    }

    void RunAudioPause()
    {
        AudioSource.PlayClipAtPoint(audioPause, transform.position);
    }
}
