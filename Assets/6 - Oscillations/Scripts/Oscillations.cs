using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    [SerializeField] private float amplitude = 5, period = 1;
    [SerializeField] private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float x = amplitude * Mathf.Sin(2f * Mathf.PI * (Time.time/period));
        transform.position = initialPosition + new Vector3(x, 0,0);
    }
}
