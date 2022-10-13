using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform targetTransform;
    [SerializeField, Range(0, 1)] private float normalizedTime;
    [SerializeField] private float duration = 5f;
    
    [Header("Colors")]
    [SerializeField] private Color initialColor;
    [SerializeField] private Color finalColor;
    
    private Vector3 initialPosition;
    private float currentTime;
    private new Renderer renderer;
    void Start()
    {
        initialPosition = transform.position;
        currentTime = 0;
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        normalizedTime = currentTime / duration;
        renderer.material.color = Vector4.Lerp(initialColor, finalColor, normalizedTime);
        transform.position = Vector3.Lerp(initialPosition, targetTransform.position, normalizedTime);
        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
    }

    private void StartTween()
    {
        initialPosition = transform.position;
        renderer.material.color = initialColor;
        currentTime = 0;
    }
}
