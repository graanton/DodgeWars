using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot : PlayerHealth
{
    [SerializeField] private int _damage = 1000;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove playerMovment) && other.TryGetComponent(out PlayerHealth player))
        {
            player.Hit(_damage);
        }
    }
    public override void OnDestroy()
    {
        if (FindObjectsOfType<Bot>().Length == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    public override void UpdateHpBar()
    {
        
    }
}
