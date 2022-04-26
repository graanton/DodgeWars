using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAttack : PlayerAttackBase
{
    [SerializeField] private float _hitRate = 0.1f;
    private PlayerHealth _currentPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove playerMovment) && other.TryGetComponent(out PlayerHealth player))
        {
            _currentPlayer = player;
            StartCoroutine(StartDamagingCurrentPlayer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove playerMovment) && other.TryGetComponent(out PlayerHealth player))
        {
            _currentPlayer = null;
        }
    }

    IEnumerator StartDamagingCurrentPlayer()
    {
        while (_currentPlayer != null)
        {
            _currentPlayer.Hit(_damage);
            yield return new WaitForSeconds(_hitRate);
        }
    }
}
