using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public List<GameObject> hitPegs;

    public static LevelManager Instance { get { return instance; } }

    public int currentPlayPegHit = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    public void KillPeg(GameObject peg)
    {
        Destroy(peg);
    }
}
