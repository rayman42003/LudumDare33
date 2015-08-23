using UnityEngine;
using System.Collections;

public class HideInAble : MonoBehaviour {
    public float speedFactor = 0.5f;
    public bool disableJumping = true;
    public float hideTime = 1.0f;

    private GameObject toHide = null;
    private bool hasKillable = false;
    private bool busy = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (!busy && other.gameObject.name == "Player" && 
            (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            if (toHide == null)
            {
                Hide(other.gameObject);
                Debug.Log("Hiding");
            }
            else
            {
                UnHide();
                Debug.Log("Unhiding");
            }
        }
    }

    public void Hide(GameObject obj)
    {
        if (toHide == null)
        {
            toHide = obj;
            if (toHide.GetComponent<Killable>())
            {
                hasKillable = true;
                toHide.GetComponent<Killable>().enabled = false;
            }
            Movable movable = toHide.GetComponent<Movable>();
            movable.moveSpeed = movable.moveSpeed * speedFactor;
            movable.jumpDisabled = disableJumping;
            busy = true;
            StartCoroutine(Busy());
        }
    }

    private IEnumerator Busy()
    {
        yield return new WaitForSeconds(hideTime);
        busy = false;
    }

    public void UnHide()
    {
        if (hasKillable)
            toHide.GetComponent<Killable>().enabled = true;
        Movable movable = toHide.GetComponent<Movable>();
        movable.moveSpeed = movable.moveSpeed / speedFactor;
        movable.jumpDisabled = false;
        toHide = null;
        hasKillable = true;
        busy = true;
        StartCoroutine(Busy());
    }
}
