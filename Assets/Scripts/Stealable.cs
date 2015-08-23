using UnityEngine;
using System.Collections;

public class Stealable : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Space))
            if(other.gameObject.GetComponent<PlayerControl>().canSteal)
                Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
