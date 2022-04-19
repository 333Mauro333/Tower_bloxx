using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HingeJoint))]

public class CubeActions : MonoBehaviour
{
    [SerializeField] Camera camera = null;

    Material m = null;
    Rigidbody rb = null;
    HingeJoint hj = null;


    void Awake()
    {
        m = GetComponent<Material>();
        rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
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
    public void setConnectionBody(Rigidbody craneRb)
    {
        hj.connectedBody = craneRb;
    }
    public void Throw()
    {
        rb.isKinematic = false;
        hj.connectedBody = null;
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
