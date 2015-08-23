using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    public LayerMask attackLayer;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
            Attack(other.gameObject.GetComponent<Killable>());
    }

	public void Attack(Killable character)
    { 
        character.Kill();
    }
}
