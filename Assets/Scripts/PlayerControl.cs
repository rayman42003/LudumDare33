using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    private Movable player;
    public bool canSteal = true;

    // Use this for initialization
    void Start() {
        player = GetComponent<Movable>();
        TurnRight();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            TurnLeft();
            player.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            TurnRight();
            player.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            player.Jump();
    }

    // Player sprite is facing left;
    private void TurnLeft()
    {
        GetComponentInParent<SpriteRenderer>().flipX = false;
    }
    private void TurnRight()
    {
        GetComponentInParent<SpriteRenderer>().flipX = true;
    }
}
