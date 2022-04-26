using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BotMove : PlayerMoveBase
{
    [SerializeField] private float _dashTime = 1f;
    [SerializeField] private float _dashSpeed = 12f;
    [SerializeField] private float _minTimeToDash = 3;
    [SerializeField] private float _maxTimeToDash = 8;
    [SerializeField][Range(1, 10000)] private int _randomDepth = 1000;
    private PlayerMove _target;
    private bool _dashing;

    private void Start()
    {
        _target = FindObjectOfType<PlayerMove>();
        StartDashing();
    }

    private void Update()
    {
        if (_dashing == false && _target != null)
        {
            Move();
        }
        
    }

    public override void StartDashing()
    {
        StartCoroutine(Dash());
    }

    public override void Move()
    {
        Vector3 direction = (_target.transform.position - transform.position);
        direction.y = 0;
        _playerBody.velocity = direction.normalized * _speed;
        _body.rotation = Quaternion.LookRotation(direction);
    }

    public override IEnumerator Dash()
    {
        float dashStartTime = Time.time;
        Vector3 dashDirectional = _playerBody.velocity.normalized;
        _dashing = true;
        while (Time.time < dashStartTime + _dashTime)
        {
            _playerBody.velocity = dashDirectional * _dashSpeed;
            yield return null;
        }
        _dashing = false;
        yield return new WaitForSeconds(Random.Range(_minTimeToDash * _randomDepth, _maxTimeToDash * _randomDepth) / _randomDepth);
        StartDashing();
    }
}
