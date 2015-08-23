using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    private LevelManager level;
    private bool triggered;

    void Start () {
        level = FindObjectOfType<LevelManager>();
        triggered = false;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player" && !triggered)
        {
            level.checkpoint = gameObject.transform;
            triggered = true;
        }
	}
}
