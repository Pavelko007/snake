using UnityEngine;

namespace Snake
{
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
}
