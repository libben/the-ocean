using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private string SceneName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
        //Debug.Log(SceneName);
        
        if (SceneName == "PregameScroll")
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("PrototypeRoom");
            }
        }  

        if(SceneName == "Credits")
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("PregameScroll");
    }

    public void StartCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
