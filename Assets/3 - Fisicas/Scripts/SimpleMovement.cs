using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private CustomVector velocity, acceleration, position;
    private CustomVector displacement;

    [SerializeField] private Transform targetPosition;

    private void Awake()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        displacement = velocity * Time.fixedDeltaTime;
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        transform.position = position;
        acceleration = targetPosition.position - transform.position;
    }
}
