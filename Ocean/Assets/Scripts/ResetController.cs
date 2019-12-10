using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheOcean {
public class ResetController : MonoBehaviour
{
    private PlayerController Player;
    private PlayerInput Input;
    private WorldsController WorldManager;
    private LevelController LevelCtrl;
    private GameObject LvlObject = null;
    [SerializeField] private AudioSource Source;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        WorldManager = GameObject.FindGameObjectWithTag("ScriptHome").GetComponent<WorldsController>();
    }

    public void NotifyNewLevel(GameObject lvl)
    {
        print("Reset updating new level");
        LvlObject = lvl;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.ResetPressed)
        {
            ResetWithSound(false);
        }
    }

    public void Reset()
    {
        ResetWithSound(true);
    }
    private void ResetWithSound(bool enable)
    {
        if (enable)
        {
            Source.Play();
        }
        Player.Reset();
        LvlObject.GetComponent<Level>().ResetObjects();
        WorldManager.Reset();
    }
}
}