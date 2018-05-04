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

    private void GameOver()
    {
        Time.timeScale = 0;
        screenManager.ShowGameOverSceen();
    }

    public void StartGame()
    {
        GetComponent<Spawner>().RespawnAll();//todo
    }

    public void Restart()
    {
        Time.timeScale = 1;
        spawner.RespawnAll();
        Debug.Log("restart");
    }
}
