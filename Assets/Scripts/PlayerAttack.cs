using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAttackBase
{
    [SerializeField] private float _range;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] protected GameObject _unAttack;
    [SerializeField] private BulletBase _bullet;

    public DynamicJoystick _attackController { set; get; }

    private bool _findNearEnemy;

    private void Update()
    {
        Aiming();
    }

    private void Aiming()
    {
        Vector2 attackDirection = _attackController.Direction;
        if (attackDirection != Vector2.zero)
        {
            if (_unAttack.activeSelf == false)
            {   
                _unAttack.SetActive(true);
                _intedToAttack = true;
                _findNearEnemy = false;
            }
            
            Vector3 vievingVector = new Vector3(_attackController.Horizontal, 0, _attackController.Vertical);
            _unAttack.transform.rotation = Quaternion.LookRotation(vievingVector);
        }
        
        else if (_attackController.isPressed)
        {
            _intedToAttack = true;
            _findNearEnemy = true;
        }

        else
        {
            if (_intedToAttack)
            {
                _intedToAttack = false;
                if (_canShooting)
                {
                    if (_findNearEnemy)
                    {
                        Bot[] allBots = FindObjectsOfType<Bot>();
                        Vector3 nearBot = allBots[0].transform.position;
                        foreach (Bot bot in allBots)
                        {
                            if (Vector3.Distance(bot.transform.position, transform.position) < Vector3.Distance(nearBot, transform.position))
                            {
                                nearBot = bot.transform.position;
                                _unAttack.transform.rotation = Quaternion.LookRotation((nearBot - transform.position).normalized);
                                
                            }
                        }
                        Shoot();
                    }
                    else
                    {
                        Shoot();
                    }
                }
            }
            _unAttack.SetActive(false);
        }
    }

    private void Reload()
    {
        StartCoroutine(Reloading());
    }

    protected BulletBase CreateBullet()
    {
        BulletBase createdBullet = Instantiate(_bullet, _unAttack.transform.position, _unAttack.transform.rotation);
        createdBullet._owner = _owner;
        createdBullet._damage = _damage;
        createdBullet._range = _range;
        return createdBullet;
    }

    protected virtual void Shoot()
    {
        BulletBase createdBullet = CreateBullet();
        createdBullet.Push(_unAttack.transform.forward);
        Reload();
    }

    private IEnumerator Reloading()
    {
        _canShooting = false;
        yield return new WaitForSeconds(_fireRate);
        _canShooting = true;
    }
}
