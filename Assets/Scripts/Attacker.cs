using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    public LayerMask attackLayer;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
            Attack(other.gameObject.GetComponent<Killable>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Killable toKill = other.gameObject.GetComponent<Killable>();
            if (toKill.enabled)
                Attack(toKill);
        }
    }

	public void Attack(Killable character)
    { 
        character.Kill();
    }
}
