using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject GameOverScreen;
    private List<GameObject> screens;

    void Awake()
    {
        screens = new List<GameObject>() {StartScreen, GameOverScreen};
    }

    void Start()
    {
        ShowStartSceen();
    }

    public void ShowStartSceen()
    {
        HideAll();
        StartScreen.SetActive(true);
    }

    private void HideAll()
    {
        foreach (var screen in screens)
        {
            screen.SetActive(false);
        }
    }

    public void ShowGameOverSceen()
    {
        HideAll();
        GameOverScreen.SetActive(true);
    }
}
