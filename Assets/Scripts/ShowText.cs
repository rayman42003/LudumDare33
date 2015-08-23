using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowText : MonoBehaviour {
    public string text;

    private Canvas canvas;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            canvas.enabled = true;
            canvas.GetComponentInChildren<Text>().text = text;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            canvas.enabled = false;

        }
    }

	// Use this for initialization
	void Start () {
        canvas = FindObjectOfType<Canvas>();
        canvas.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
