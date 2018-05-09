using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private ScreenManager screenManager;
    private Spawner spawner;

    [Inject]
    public void Construct(ScreenManager screenManager, Spawner spawner)
    {
        this.screenManager = screenManager;
        this.spawner = spawner;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.D))
	    {
	        GameOver();
	    }
	}

    public void GameOver()
    {
        Time.timeScale = 0;
        screenManager.ShowGameOverSceen();
    }

    public void StartGame()
    {
        Restart();
    }

    public void Restart()
    {
        screenManager.HideAll();
        Time.timeScale = 1;
        spawner.RespawnAll();
    }
}
