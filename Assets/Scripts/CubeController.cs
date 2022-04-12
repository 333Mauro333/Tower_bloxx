using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] CubeCreator cubeCreator = null;
    [SerializeField] KeyCode createCube = KeyCode.None;
    [SerializeField] KeyCode throwCube = KeyCode.None;
    [SerializeField] bool canCreate = false;

    GameObject currCube = null;
    CubeActions ca = null;


    void Start()
    {
        currCube = cubeCreator.CreateCube(new Vector3(0, 10, 0));
        ca = currCube.GetComponent<CubeActions>();
    }

    void Update()
    {
        if (Input.GetKeyDown(createCube) && currCube == null)
        {
            currCube = cubeCreator.CreateCube(new Vector3(0, 10, 0));
            ca = currCube.GetComponent<CubeActions>();
            canCreate = false;
        }

        if (Input.GetKeyDown(throwCube) && currCube != null)
        {
            ca.activateGravity();
            currCube = null;
            ca = null;
            canCreate = true;
        }
    }
}
