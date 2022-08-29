using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private CustomVector velocity, position, acceleration, force;
    private CustomVector displacement;
    private CustomVector[] accelerationDirection = new CustomVector[4] { new CustomVector(0f, -9.8f), new CustomVector(9.8f, 0f), new CustomVector(0f, 9.8f) , new CustomVector(-9.8f, 0f) };
    private int currentAcceleration = 0;
    
    private void Awake() { position = transform.position; }

    private void FixedUpdate()
    {
        velocity = velocity + acceleration * (Time.fixedDeltaTime);
        position = position + velocity * (Time.fixedDeltaTime);
        
        if (position.x < -5 || position.x > 5) { position.x = Mathf.Sign(position.x) * 5; velocity.x = -velocity.x; }

        if (position.y < -5 || position.y > 5) { position.y = Mathf.Sign(position.y) * 5; velocity.y = -velocity.y; }

        transform.position = position;
    }
    
    void Update()
    {
        velocity.Draw(position, Color.red); position.Draw(Color.green); acceleration.Draw(position, Color.blue); displacement.Draw(position, Color.yellow);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            velocity *= 0;
            acceleration = accelerationDirection[(++currentAcceleration) % accelerationDirection.Length];
        }
    }
}
