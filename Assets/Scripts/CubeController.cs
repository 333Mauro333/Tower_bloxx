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
        currCube = cubeCreator.CreateCube(crane.transform.position - diff);
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

            currCube = cubeCreator.CreateCube(crane.transform.position - diff);
            ca = currCube.GetComponent<CubeActions>();

            moveUp = new Vector3(0.0f, currCube.transform.localScale.y, 0.0f);
            crane.transform.position += moveUp;
            camera.transform.position += moveUp;
        }

        if (Input.GetKeyDown(throwCube) && currCube != null)
        {
            ca.Throw();
            currCube = null;
            ca = null;
        }
    }
}
