using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

    public LayerMask attackLayer;

    void OnCollisionEnter2D(Collision2D other)
    {
        checkKill(other.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        checkKill(other.gameObject);
    }

    private void checkKill(GameObject obj)
    {
        if(obj.name == "Player")
        {
            Killable toKill = obj.GetComponent<Killable>();
            Debug.Log(toKill);
            if (toKill.enabled)
                Attack(toKill);
        }
    }


	public void Attack(Killable character)
    { 
        character.Kill();
    }
}
