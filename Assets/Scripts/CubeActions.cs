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
            ChangeTagToFloor();
        }
    }


    public void setMaterialColor(Color color)
    {
        m.color = color;
    }
    public void Throw()
    {
        rb.isKinematic = true;
    }

    void Freeze()
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }
    void ChangeTagToFloor()
    {
        gameObject.tag = "Floor";
    }
}
