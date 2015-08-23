using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public Transform checkpoint;
    private int totalStealables;

	// Use this for initialization
	void Start () {
        Stealable[] stealables = Object.FindObjectsOfType(typeof(Stealable)) as Stealable[];
        totalStealables = stealables.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Stealable[] stealables = Object.FindObjectsOfType(typeof(Stealable)) as Stealable[];
            Debug.Log((totalStealables - stealables.Length).ToString() + "/" + totalStealables.ToString());
        }
	}
}
