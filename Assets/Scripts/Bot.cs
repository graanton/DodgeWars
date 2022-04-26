using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot : PlayerHealth
{
    public override void OnDestroy()
    {
        if (FindObjectsOfType<Bot>().Length == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
