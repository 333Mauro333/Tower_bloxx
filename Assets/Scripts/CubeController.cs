using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] CubeCreator cubeCreator = null;
    [SerializeField] KeyCode createCube = KeyCode.None;
    [SerializeField] KeyCode throwCube = KeyCode.None;
    [SerializeField] bool canCreate = false;
    [SerializeField] Vector3 spawnPosition = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] Camera camera = null;

    GameObject currCube = null;
    CubeActions ca = null;


    void Start()
    {
        camera = FindObjectOfType<Camera>();
        currCube = cubeCreator.CreateCube(spawnPosition);
        ca = currCube.GetComponent<CubeActions>();
    }

    void Update()
    {
        UserInput();
    }


    void UserInput()
    {
        if (Input.GetKeyDown(createCube) && currCube == null)
        {
            Vector3 moveUp;

            currCube = cubeCreator.CreateCube(spawnPosition);
            ca = currCube.GetComponent<CubeActions>();

            moveUp = new Vector3(0.0f, currCube.transform.localScale.y, 0.0f);
            spawnPosition += moveUp;
            camera.transform.position += moveUp;
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
