using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float speed = 3;
    [SerializeField] private Vector3 offset;
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
        Vector3 followPosition = new Vector3(_target.position.x, transform.position.y, _target.position.z) + offset;
        Vector3 directional = Vector3.Lerp(startPosition, followPosition, Time.deltaTime * speed);

        transform.position = directional;
    }
}
