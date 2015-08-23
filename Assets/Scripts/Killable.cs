using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour
{
    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}