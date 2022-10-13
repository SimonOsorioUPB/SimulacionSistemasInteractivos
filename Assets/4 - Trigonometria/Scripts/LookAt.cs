using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private void Update()
    {
        Vector3 mouseWorldPosition = GetWorldMousePosition();
        float radians = Mathf.Atan2(mouseWorldPosition.y, mouseWorldPosition.x);
        RotateZ(radians);
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        Vector4 worldPosition = camera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    private void RotateZ(float radians) { transform.rotation = Quaternion.Euler(0, 0, radians * Mathf.Rad2Deg); }
}
