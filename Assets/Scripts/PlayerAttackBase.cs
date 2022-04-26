using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerHealth))]
public class PlayerAttackBase : MonoBehaviour
{
    
    [SerializeField] private protected int _damage;
    private protected bool _canShooting = true;
    private protected bool _intedToAttack = false;

    private protected PlayerHealth _owner;

    private void Awake()
    {
        _owner = GetComponent<PlayerHealth>();
    }

    public int GetBaseDamage()
    {
        return _damage;
    }

    public void AddDamage(int damage)
    {
        _damage += damage;
    }
}
