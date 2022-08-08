using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestingVector : MonoBehaviour
{
    [SerializeField] private CustomVector customVector1, customVector2;
    
    [SerializeField] private Color vector1Color = Color.red, vector2Color = Color.green;
    [SerializeField] private Color lerpVectorColor = Color.yellow, differenceVectorColor = Color.magenta;

    [SerializeField, Range(0f, 1f)] private float lerpingFactor = 0;

    private void Update()
    {
        //Vectors
        customVector1.Draw(vector1Color);
        customVector2.Draw(vector2Color);
        //Lerp
        CustomVector lerpVector = customVector1.Lerp(customVector2, lerpingFactor);
        lerpVector.Draw(lerpVectorColor);
        //Difference
        CustomVector differenceVector = customVector1 - lerpVector;
        differenceVector.Draw(lerpVector, differenceVectorColor);
    }
}
