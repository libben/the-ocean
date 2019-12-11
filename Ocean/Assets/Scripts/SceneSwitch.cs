using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private string SceneName;

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
        
        if (SceneName == "PregameScroll")
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("OceanBase");
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
