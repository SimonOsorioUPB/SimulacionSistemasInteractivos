using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionFall : MonoBehaviour
{
    private Camera camera;
    public enum Mode { Friction, FluidFriction }
    [SerializeField] private Mode frictionMode;
    
    [Header("Variables")]
    [SerializeField] private float mass;
    [SerializeField] private CustomVector velocity;
    [SerializeField] private CustomVector acceleration;
    [SerializeField] private CustomVector position;

    [Header("Forces")]
    [SerializeField] private CustomVector gravity;
    private CustomVector netForce;
    private CustomVector weight;

    
    [Header("Constants")]
    [Range(0f, 1f)] [SerializeField] private float frictionCoeficent = 0.9f;
    [Range(0f, 1f)] [SerializeField] private float dampingFactor = 0.9f;


    private void Start() { position = new CustomVector(transform.position.x, transform.position.y); camera = Camera.main; }

    private void FixedUpdate()
    {
        acceleration *= 0f;
        netForce = new CustomVector(0, 0);
        weight = mass * gravity;
        ApplyForce(weight);
        if (frictionMode == Mode.FluidFriction)
        {
            if (transform.position.y > 0.0) { ApplyFriction(); }
            if (transform.position.y <= 0.0f) { ApplyFluidFriction(); }
        }
        else if (frictionMode == Mode.Friction){ ApplyFriction(); }
        Move();
    }

    private void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        CheckWorldBoxBounds();
        transform.position = new Vector3(position.x, position.y);
    }
    private void ApplyForce(CustomVector force)
    {
        netForce += force;
        acceleration = netForce / mass;
    }
    private void ApplyFriction()
    {
        CustomVector friction = -frictionCoeficent * weight.magnitude * velocity.normalized;
        ApplyForce(friction);
    }
    private void ApplyFluidFriction()
    {
        float p = 1;
        float area = transform.localScale.x;
        float fluidDragCoeficent = 1f;
        float velocityMagnitude = velocity.magnitude;
        float scalarPart = -0.5f * p * velocityMagnitude * velocityMagnitude * area * fluidDragCoeficent;
        CustomVector friction = scalarPart * velocity.normalized;
        ApplyForce(friction);
    }
    private void CheckWorldBoxBounds()
    {
        if (Mathf.Abs(position.y) > camera.orthographicSize)
        {
            velocity.y = velocity.y * -1;
            position.y = Mathf.Sign(position.y) * camera.orthographicSize;
            velocity *= dampingFactor;
        }
    }
}

