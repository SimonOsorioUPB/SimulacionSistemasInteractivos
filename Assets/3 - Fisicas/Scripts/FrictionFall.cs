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
    [Range(0f, 1f)] [SerializeField] private float dampingFactor = 0.9f;
    [Range(0f, 1f)] [SerializeField] private float frictionCoeficent = 0.9f;

    private void Start() { position = new CustomVector(transform.position.x, transform.position.y); camera = Camera.main; }

    private void FixedUpdate()
    {
        acceleration*=0f;
        netForce = new CustomVector(0, 0);
        if (frictionMode == Mode.FluidFriction)
        {
            if (transform.position.y > 0.9) { ApplyFriction();}
            if (transform.position.y <= 0.9) { ApplyFluidFriction();}
        }
        else if (frictionMode == Mode.Friction){ ApplyFriction(); }
        Move();
    }

    private void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        if(velocity.magnitude >= 10) { velocity = 10f * velocity.normalized; }
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
        if (transform.localPosition.y <= 0)
        {
            float p = 1;
            float flontalArea = transform.localScale.x;
            float fluidDragCoefficent = 1;
            float velocityMagnitude = velocity.magnitude;
            float scalarPart = -0.5f * p * velocityMagnitude * velocityMagnitude * flontalArea * fluidDragCoefficent;
            CustomVector friction = scalarPart * velocity.normalized;
            ApplyForce(friction);
        }
    }
}
