using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerMoveBase
{
    [SerializeField] private DynamicJoystick _moveController;
    [SerializeField] private float _dashSpeed = 8;
    [SerializeField] private float _dashTime = 3;
    private bool _dashing;

    private void Update()
    {
        if (_dashing == false)
        {
            Move();
        }
    }

    public override void Move()
    {
        float moveX = _moveController.Horizontal;
        float moveY = _moveController.Vertical;
        Vector3 inputVector = new Vector3(moveX, 0, moveY);
        if (inputVector != Vector3.zero)
        {
            _body.rotation = Quaternion.LookRotation(inputVector);
        }
        Vector3 moveVector = transform.TransformDirection(inputVector) * _speed;
        moveVector.y = _playerBody.velocity.y;
        _playerBody.velocity = moveVector;
    }

    public override void StartDashing()
    {
        if (_dashing == false)
        {
            StartCoroutine(Dash());
        }
    }

    public override IEnumerator Dash()
    {
        _dashing = true;
        float startDashTime = Time.time;
        while (Time.time < startDashTime + _dashTime)
        {
            _playerBody.velocity = _body.forward * _dashSpeed;
            yield return null;
        }
        _dashing = false;

    }
}
