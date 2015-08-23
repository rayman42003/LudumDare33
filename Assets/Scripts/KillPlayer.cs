using UnityEngine;
using System.Collections;

public class KillPlayer : Killable {

    private LevelManager level;

    public float respawnTime = 1.0f;
    private float gravityScale;

    void Start()
    {
        level = FindObjectOfType<LevelManager>();   
        gravityScale = gameObject.GetComponent<Rigidbody2D>().gravityScale;
    }

    public override void Kill()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
        body.velocity = Vector2.zero;

        gameObject.GetComponent<Renderer>().enabled = false;

        gameObject.GetComponent<PlayerControl>().enabled = false;

        level.ResetBarrels();
        StartCoroutine(RespawnTime(gravityScale));
    }

    public IEnumerator RespawnTime(float gravityScale)
    {
        yield return new WaitForSeconds(respawnTime);
        Ressurect(gravityScale);
    }

    public void Ressurect(float gravityScale)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        gameObject.GetComponent<Rigidbody2D>().position = level.checkpoint.position;

        gameObject.GetComponent<PlayerControl>().enabled = true;

        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
