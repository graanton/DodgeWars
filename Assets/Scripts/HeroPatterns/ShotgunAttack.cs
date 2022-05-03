using System;
using UnityEngine;

public class ShotgunAttack : PlayerAttack
{
    [SerializeField] private int _bulletCount = 3;
    [SerializeField] [Range(1, 360)] private float _shootField = 90;

    private void Start()
    {
        if (_bulletCount <= 1)
        {
            throw new Exception("it`s a shotgun, don`t pistol");
        }
    }

    protected override void Shoot()
    {
        for (int b = 0; b < _bulletCount; b++)
        {
            BulletBase bullet = CreateBullet();
            bullet.transform.Rotate(new Vector3(0, _shootField / 2 - _shootField / (_bulletCount - 1) * b, 0));
            bullet.Push(bullet.transform.forward);
        }
        Reload();
    }
}
