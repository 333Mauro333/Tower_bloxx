using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(Rigidbody))]

public class CubeActions : MonoBehaviour
{
    [SerializeField] Camera camera = null;

    Material m = null;
    Rigidbody rb = null;


    void Awake()
    {
        m = GetComponent<Material>();
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Freeze();
            ChangeCubeTag();
        }
    }


    public void setMaterialColor(Color color)
    {
        m.color = color;
    }
    public void activateGravity()
    {
        rb.isKinematic = false;
    }
    
    void Freeze()
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }
    void ChangeCubeTag()
    {
        gameObject.tag = "Floor";
    }
}
