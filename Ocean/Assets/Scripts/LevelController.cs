using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean
{
public class LevelController : MonoBehaviour
{
    private GameObject Player;
    private GameObject CurrentLevel = null;
    private GameObject[] Levels;
    private CameraController Cam;
    private GameObject ScriptHome;


    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptHome = gameObject;
        Levels = GameObject.FindGameObjectsWithTag("lvl");
        InitializeLevel();
    }

    void FixedUpdate()
    {
        UpdateLevel();
    }

    private void InitializeLevel()
    {
        print("Initializing level");
        CurrentLevel = DistanceFinder.FindMinimumDistance(Player, Levels);
        Cam.InitializeLevel(CurrentLevel);
        Player.BroadcastMessage("NotifyNewLevel");
        ScriptHome.BroadcastMessage("NotifyNewLevel", CurrentLevel);
    }

    void UpdateLevel()
    {
        GameObject newLevel = DistanceFinder.FindMinimumDistance(Player, Levels);
        if (CurrentLevel != newLevel)
        {
            print("Player changed levels");
            CurrentLevel = newLevel;
            Cam.NotifyNewLevel(CurrentLevel);
            Player.BroadcastMessage("NotifyNewLevel");
            ScriptHome.BroadcastMessage("NotifyNewLevel", CurrentLevel);
        }
    }
}
}