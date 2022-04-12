using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(Rigidbody))]

public class CubeActions : MonoBehaviour
{
    Material m = null;
    Rigidbody rb = null;


    void Awake()
    {
        m = GetComponent<Material>();
        rb = GetComponent<Rigidbody>();
    }


    public void setMaterialColor(Color color)
    {
        m.color = color;
    }
    public void activateGravity()
    {
        rb.isKinematic = false;
    }
}
