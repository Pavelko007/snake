using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject StartScreen;

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
        Debug.LogError("not implemented");
    }
}
