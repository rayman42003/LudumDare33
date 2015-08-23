using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideInAble : MonoBehaviour
{
    public float speedFactor = 0.5f;
    public bool disableJumping = true;
    public float hideTime = 1.0f;
    public LayerMask whosHiding;
    public LayerMask whosSearching;

    public Sprite emptySprite;
    public Sprite hidingSprite;

    private GameObject toHide = null;
    private int originalLayer = -1;
    private bool hasKillable = false;
    private bool busy = false;

    void Update()
    {
        if (toHide != null)
            gameObject.transform.position = toHide.transform.position;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!busy && other.gameObject.name == "Player" &&
            (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            if (toHide == null)
                Hide(other.gameObject);
            else
                UnHide();
        }
    }

    public void Hide(GameObject obj)
    {
        toHide = obj;
        if (toHide.GetComponent<Killable>() != null)
        {
            hasKillable = true;
            toHide.GetComponent<Killable>().enabled = false;
        }

        Movable movable = toHide.GetComponent<Movable>();
        movable.moveSpeed = movable.moveSpeed * speedFactor;
        movable.jumpDisabled = disableJumping;

        originalLayer = obj.GetComponent<SpriteRenderer>().sortingOrder;
        obj.GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1;

        obj.transform.position = gameObject.transform.position;
        gameObject.GetComponent<SpriteRenderer>().sprite = hidingSprite;

        ignoreLayerCollisions(whosHiding, whosSearching, true);

        busy = true;
        StartCoroutine(Busy());
    }

    private void ignoreLayerCollisions(LayerMask first, LayerMask second, bool enabled)
    {
        List<int> firstInts = new List<int>();
        List<int> secondInts = new List<int>();
        for (int i = 0; i < 32; i++)
        {
            if (((first >> i) & 1) == 1)
                firstInts.Add(i);
            if (((second >> i) & 1) == 1)
                secondInts.Add(i);
        }
        foreach (int firstInt in firstInts)
            foreach (int secondInt in secondInts)
                Physics2D.IgnoreLayerCollision(firstInt, secondInt, enabled);
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

        toHide.GetComponent<SpriteRenderer>().sortingOrder = originalLayer;

        toHide = null;
        hasKillable = true;
        originalLayer = -1;

        gameObject.GetComponent<SpriteRenderer>().sprite = emptySprite;

        ignoreLayerCollisions(whosHiding, whosSearching, false);

        busy = true;
        StartCoroutine(Busy());
    }
}
