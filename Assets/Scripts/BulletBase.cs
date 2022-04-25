using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BulletBase : MonoBehaviour
{
    [SerializeField] private float _shotSpeed = 1;

    private Rigidbody _myPhysic;

    public float _range { set; get; }
    public int _damage { set; get; }

    public PlayerHealth _owner { set; get; }

    private void Awake()
    {
        _myPhysic = GetComponent<Rigidbody>();
    }

    public void Push(Vector3 velocity)
    {
        Destroy(gameObject, _range);
        _myPhysic.velocity = velocity.normalized * _shotSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth player) && player != _owner)
        {
            player.Hit(_damage);
            Destroy(gameObject);
        }
    }

}
