using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    private enum MovementMode{ Acceleration, Velocity }
    [SerializeField] private MovementMode movementMode;
    
    [HideInInspector] public CustomVector Velocity, Acceleration, Position;
    [SerializeField] public Transform targetPosition;
    [SerializeField] private float speed;

    private void Awake()
    {
        Position = transform.position;
    }

    private void FixedUpdate()
    {
        switch (movementMode)
        {
            case MovementMode.Velocity:
                Velocity = targetPosition.position - transform.position;
                Velocity.Normalize();
                Velocity *= speed;
                break;
            case MovementMode.Acceleration:
                Acceleration = targetPosition.position - transform.position;
                break;
        }
        Move();
    }

    public void Move()
    {
        Velocity += Acceleration * Time.fixedDeltaTime;
        Position += Velocity * Time.fixedDeltaTime;
        transform.position = Position;
    }
}
