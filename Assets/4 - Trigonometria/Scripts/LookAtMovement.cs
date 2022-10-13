using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LinearMovement))]
public class LookAtMovement : MonoBehaviour
{
    private LinearMovement movement;
    private void Awake()
    {
        movement = GetComponent<LinearMovement>();
    }
    private void Update()
    {
        float radians = Mathf.Atan2(movement.Velocity.y, movement.Velocity.x);
        RotateZ(radians);
    }
    private void RotateZ(float radians) { transform.rotation = Quaternion.Euler(0, 0, radians * Mathf.Rad2Deg); }
}
