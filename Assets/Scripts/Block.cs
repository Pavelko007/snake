using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Color DefaultColor;

	// Use this for initialization
	void Awake() {
		ChangeColor(DefaultColor);
	}

    public void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
	
}
