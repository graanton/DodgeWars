using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RotateBorder : MonoBehaviour
{
    [SerializeField] private float speedRotation;

    private void Update()
    {
        transform.Rotate(Vector3.up, speedRotation * Time.deltaTime);
    }
}
