using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtIndependent : MonoBehaviour
{
    [SerializeField] public Transform target;
    private void Update()
    {
        Vector2 thisPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 forward = new Vector2(target.position.x, target.position.y) - thisPosition;
        float radians = Mathf.Atan2(forward.y, forward.x);
        RotateZ(radians);
    }
    private void RotateZ(float radians) { transform.rotation = Quaternion.Euler(0, 0, radians * Mathf.Rad2Deg); }
}
