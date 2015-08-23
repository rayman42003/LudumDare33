using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    private Movable player;
    public bool canSteal = true;
	// Use this for initialization
	void Start () {
        player = GetComponent<Movable>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            player.MoveLeft();
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            player.MoveRight();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            player.Jump();

        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(Application.loadedLevel);
	}
}
