using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct CustomVector
{
    //Variables principales (inicializadas)
    public float x, y;
    public CustomVector(float x, float y) { this.x = x; this.y = y; }

    //Operadores principales
    public CustomVector Sum(CustomVector other) { return new CustomVector(x + other.x, y + other.y); }
    public CustomVector Sub(CustomVector other) { return new CustomVector(x - other.x, y - other.y); }
    public CustomVector Scale(float f) { return new CustomVector(x * f, y * f); }

    //Operadores complejos internos
    public static CustomVector operator +(CustomVector a, CustomVector b) { return a.Sum(b); }
    public static CustomVector operator -(CustomVector a, CustomVector b) { return a.Sub(b); }
    public static CustomVector operator *(CustomVector a, float b) { return a.Scale(b); }
    
    public static implicit operator Vector3(CustomVector a) { return new Vector3(a.x, a.y, 0); }
    public CustomVector Lerp(CustomVector b, float c) { return (this + (b - this) * c); }

    //Inspector Output
    public void Draw(Color color){ Debug.DrawLine(new Vector3(0,0,0), new Vector3(x,y,0), color, 0); }
    public void Draw(CustomVector origin, Color color)
    {
        Debug.DrawLine(new Vector3(origin.x, origin.y, 0), new Vector3(x+origin.x, y+origin.y, 0), color, 0);
    }

}
