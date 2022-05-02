using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private Vector3 offset;

    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        if (_target != null)
        {
            Follow();
        }
        
    }
    private void Follow()
    {
        Vector3 startPosition = transform.position;
        Vector3 followPosition = _target.position + offset;
        Vector3 directional = Vector3.Lerp(startPosition, followPosition, Time.deltaTime * speed);

        transform.position = directional;
    }
}
