using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerHealth))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _unAttack;
    [SerializeField] private BulletBase _bullet;
    [SerializeField] private DynamicJoystick _attackController;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private int _damage;
    [SerializeField] private float _range;
    private bool _canShooting = true;
    private bool _intedToAttack = false;

    private PlayerHealth _owner;

    private void Awake()
    {
        _owner = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        Aiming();
    }

    public void Aiming()
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

    public int GetBaseDamage()
    {
        return _damage;
    }

    public void AddDamage(int damage)
    {
        _damage += damage;
    }

    IEnumerator Reload()
    {
        _canShooting = false;
        yield return new WaitForSeconds(_fireRate);
        _canShooting = true;
    }

}
