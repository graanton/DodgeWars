using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAttackBase
{
    [SerializeField] private float _range;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private GameObject _unAttack;
    [SerializeField] private BulletBase _bullet;
    [SerializeField] private DynamicJoystick _attackController;

    private void Update()
    {
        Aiming();
    }

    private void Aiming()
    {
        Vector2 attackDirection = new Vector2(_attackController.Horizontal, _attackController.Vertical);
        if (attackDirection != Vector2.zero)
        {
            if (_unAttack.activeSelf == false)
            {   
                _unAttack.SetActive(true);
                _intedToAttack = true;
            }
            Vector3 vievingVector = new Vector3(_attackController.Horizontal, 0, _attackController.Vertical);
            _unAttack.transform.rotation = Quaternion.LookRotation(vievingVector);
        }
        else
        {
            if (_intedToAttack)
            {
                _intedToAttack = false;
                if (_canShooting)
                {
                    Shoot();
                }
            }
            _unAttack.SetActive(false);
        }
    }
    private void Shoot()
    {
        BulletBase createdBullet = Instantiate(_bullet, _unAttack.transform.position, _unAttack.transform.rotation);
        createdBullet._owner = _owner;
        createdBullet._damage = _damage;
        createdBullet._range = _range;
        createdBullet.Push(_unAttack.transform.forward);

        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        _canShooting = false;
        yield return new WaitForSeconds(_fireRate);
        _canShooting = true;
    }
}
