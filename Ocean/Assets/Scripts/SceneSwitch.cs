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
        if (Input.anyKey)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneName = currentScene.name;

            switch(currentScene.name)
            {
                case "PregameScroll":
                    SceneCounter.counter = 0;
                    SceneManager.LoadScene("OceanBase");
                    break;
                case "PostgameScroll":
                    SceneManager.LoadScene("Credits");
                    break;
                case "Credits":
                    SceneManager.LoadScene("TitleScreen");
                    break;
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
