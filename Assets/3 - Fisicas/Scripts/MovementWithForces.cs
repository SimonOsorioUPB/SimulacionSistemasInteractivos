using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWithForces : MonoBehaviour
{
    [SerializeField] private float mass = 5;
    
    [Header("Forces")]
    [SerializeField] private CustomVector gravity = new CustomVector(0, -9.8f);
    [SerializeField] private CustomVector wind;
    
    private CustomVector velocity, acceleration, position;
    
    [Header("Damping")]
    [Range(0,1)][SerializeField] private float dampingFactor = 0.8f;

    private void Awake() { position = transform.position; }

    private void FixedUpdate()
    {
        acceleration *= 0; ApplyForce(gravity + wind); Move();
    }

    public void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        CheckBounds(5,5);
        transform.position = position;
    }

    void CheckBounds(float xMax, float yMax)
    {
        if (position.x < -xMax || position.x > xMax)
        {
            position.x = Mathf.Sign(position.x) * 5; velocity.x = -velocity.x; velocity *= dampingFactor;
        }
        if (position.y < -yMax || position.y > yMax)
        {
            position.y = Mathf.Sign(position.y) * 5; velocity.y = -velocity.y; velocity *= dampingFactor;
        }
    }
    
    void ApplyForce(CustomVector force)
    {
        acceleration = force / mass;
    }
}
