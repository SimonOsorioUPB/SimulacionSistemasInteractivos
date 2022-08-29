using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct CustomVector
{
    //Variables principales (inicializadas)
    public float x, y;

    public float magnitude => Mathf.Sqrt(x * x + y * y);
    public CustomVector(float x, float y) { this.x = x; this.y = y; }

    //Operadores principales
    public CustomVector Sum(CustomVector other) { return new CustomVector(x + other.x, y + other.y); }
    public CustomVector Sub(CustomVector other) { return new CustomVector(x - other.x, y - other.y); }
    public CustomVector Scale(float f) { return new CustomVector(x * f, y * f); }
    public CustomVector Lerp(CustomVector b, float c) { return (this + (b - this) * c); }
    
    //Operadores complejos internos
    public static CustomVector operator +(CustomVector a, CustomVector b) { return a.Sum(b); }
    public static CustomVector operator -(CustomVector a, CustomVector b) { return a.Sub(b); }
    public static CustomVector operator *(CustomVector a, float b) { return a.Scale(b); }
    public static CustomVector operator *(float b, CustomVector a) { return a.Scale(b); }
    public static CustomVector operator /(CustomVector a, float b) { return a.Scale(1f/b); }
    public static implicit operator Vector3(CustomVector a) { return new Vector3(a.x, a.y, 0); }
    public static implicit operator CustomVector(Vector3 a) { return new CustomVector(a.x, a.y); }

    //Inspector Output
    public void Draw(Color color){ Debug.DrawLine(new Vector3(0,0,0), new Vector3(x,y,0), color, 0); }
    public void Draw(CustomVector origin, Color color)
    {
        Debug.DrawLine(new Vector3(origin.x, origin.y, 0), new Vector3(x+origin.x, y+origin.y, 0), color, 0);
    }
    
    //Normalización Vector
    public CustomVector normalized
    {
        get
        {
            float distance = magnitude;
            if (distance < 0.0001) { return new CustomVector(0,0); }
            else { return new CustomVector(x / distance, y / distance); }
        }
    }
    public void Normalize()
    {
        float magnitudeCache = magnitude;
        if (magnitudeCache < 0.0001) { x = 0; y = 0; }
        x = x / magnitudeCache; y = y / magnitudeCache;
    }

}
