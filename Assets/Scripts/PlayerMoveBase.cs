using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveBase : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Transform _body;
    protected Rigidbody _playerBody;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody>();
    }

    public virtual void Move()
    {
        
    }

    public virtual void StartDashing()
    {
        
    }

    public virtual IEnumerator Dash()
    {
        return null;
    }

    public Transform GetBody()
    {
        return _body;
    }
}
