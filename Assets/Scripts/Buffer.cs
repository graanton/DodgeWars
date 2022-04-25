using System;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    [SerializeField] private float _kBuff = 0.1f;
    [SerializeField] private float _kScale = 0.1f;
    [SerializeField] private float _rotateSpeed = 3;
    private void Update()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerAttack playerAttackComponet))
        {
            
            playerAttackComponet.AddDamage(Convert.ToInt32(playerAttackComponet.GetBaseDamage() * _kBuff));
        }
        if (other.TryGetComponent(out PlayerHealth player))
        {
            player.transform.localScale += Vector3.one * _kScale;
            player.AddMaxHealth(Convert.ToInt32(player.baseMaxHealth * _kBuff));
            Destroy(gameObject);
        }

    }

}
