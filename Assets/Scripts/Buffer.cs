using System;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    [SerializeField] private float _kBuffHealth = 0.1f;
    [SerializeField] private float _kBuffDamage = 0.1f;
    [SerializeField] private float _kScale = 0.1f;
    [SerializeField] private float _rotateSpeed = 3;
    private void Update()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerAttackBase playerAttackComponet))
        {
            
            playerAttackComponet.AddDamage(Convert.ToInt32(playerAttackComponet.GetBaseDamage() * _kBuffDamage));
        }
        if (other.TryGetComponent(out PlayerHealth player))
        {
            player.transform.localScale += Vector3.one * _kScale;
            player.AddMaxHealth(Convert.ToInt32(player.baseMaxHealth * _kBuffHealth));
            Destroy(gameObject);
        }

    }

}
