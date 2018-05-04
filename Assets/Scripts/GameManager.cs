using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private ScreenManager screenManager;

    [Inject]
    public void Construct(ScreenManager screenManager)
    {
        this.screenManager = screenManager;
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
        GetComponent<Spawner>().SpawnSnake();//todo
    }

    public void Restart()
    {
        Debug.Log("restart");
    }
}
