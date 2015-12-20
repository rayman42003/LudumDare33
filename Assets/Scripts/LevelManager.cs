using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Transform checkpoint;
    private int totalStealables;

	void Start () {
        Stealable[] stealables = Object.FindObjectsOfType(typeof(Stealable)) as Stealable[];
        totalStealables = stealables.Length;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Stealable[] stealables = Object.FindObjectsOfType(typeof(Stealable)) as Stealable[];
            Debug.Log((totalStealables - stealables.Length).ToString() + "/" + totalStealables.ToString());
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetBarrels()
    {
        HideInAble[] barrels = FindObjectsOfType<HideInAble>() as HideInAble[];
        foreach (HideInAble barrel in barrels)
            barrel.Reset();
    }
}
