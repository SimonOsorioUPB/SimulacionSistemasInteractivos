using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PolarExperiments : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float angleDeg;

    [Header("Speed and acceleration")]
    [SerializeField] float angularSpeed;
    [SerializeField] float radialSpeed;
    [SerializeField] float radialAcceleration;
    [SerializeField] float angularAcceleration;

    [Header("World")]
    [SerializeField] Transform bolita;
    [SerializeField] Camera camara;

    // Start is called before the first frame update
    private void Start()
    {
        Assert.IsNotNull(bolita, "Bolita reference is required");
    }

    // Update is called once per frame
    private void Update()
    {
        //incrementa en angulo y radio
        angleDeg += angularSpeed * Time.deltaTime;
        radius += radialSpeed * Time.deltaTime;

        //update the bolita position
        bolita.position = PolarToCartesian(radius, angleDeg);
        Debug.DrawLine(Vector3.zero, bolita.position);

        //if (Mathf.Abs(bolita.position.x) >= camara.orthographicSize)
        //{
        //    if (Mathf.Abs(radialAcceleration) >= 5)
        //    {
        //        radialAcceleration = -radialAcceleration;
        //    }
        //    else
        //    {
        //        radialSpeed = -radialSpeed;
        //    }
        //}
    }

    private Vector3 PolarToCartesian(float radius, float angle)
    {
        float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(x, y, 0);
    }

}
