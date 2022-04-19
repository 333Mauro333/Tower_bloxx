using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CubeController : MonoBehaviour
{
    [SerializeField] CubeCreator cubeCreator = null;
    [SerializeField] KeyCode createCube = KeyCode.None;
    [SerializeField] KeyCode throwCube = KeyCode.None;
    [SerializeField] GameObject crane = null;
    [SerializeField] Camera camera = null;
    
    Vector3 diff = new Vector3(0.0f, 0.75f, 0.0f);
    GameObject currCube = null;
    CubeActions ca = null;


    void Start()
    {
        camera = FindObjectOfType<Camera>();
        CreateCube();
    }

    void Update()
    {
        UserInput();
    }


    void UserInput()
    {
        if (Input.GetKeyDown(createCube) && currCube == null)
        {
            CreateCube();
            MoveCamera();
            MoveCrane();
        }

        if (Input.GetKeyDown(throwCube) && currCube != null)
        {
            ThrowCube();
        }
    }
    void CreateCube()
    {
        currCube = cubeCreator.CreateCube(crane.transform.position - diff);
        ca = currCube.GetComponent<CubeActions>();
        ca.setConnectionBody(crane.GetComponent<Rigidbody>());
    }
    void MoveCamera()
    {
        camera.transform.position += new Vector3(0.0f, currCube.transform.localScale.y, 0.0f);
    }
    void MoveCrane()
    {
        crane.transform.position += new Vector3(0.0f, currCube.transform.localScale.y, 0.0f);
    }
    void ThrowCube()
    {
        ca.Throw();
        currCube = null;
        ca = null;
    }
}
