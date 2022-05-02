using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterAttack : PlayerAttack
{

    [SerializeField] private float _bulletsCount;
    [SerializeField] private float _bulletSpacing;

    protected override void Shoot()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        _canShooting = false;
        Vector3 attackDirection = _unAttack.transform.forward;
        for (int i = 0; i < _bulletsCount; i++)
        {
            BulletBase bullet = CreateBullet();
            bullet.Push(attackDirection);
            yield return new WaitForSeconds(_bulletSpacing);
        }
        _canShooting = true;
    }



}
