using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToMousePosition : MonoBehaviour
{
    private Camera camera;
    private void Awake() { camera = Camera.main; }
    private void Update() { transform.position = camera.ScreenToWorldPoint(Input.mousePosition); }
}
