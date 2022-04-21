using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Tower_Bloxx
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField] CubeCreator cubeCreator = null;
        [SerializeField] KeyCode createCube = KeyCode.None;
        [SerializeField] KeyCode throwCube = KeyCode.None;
        [SerializeField] GameObject crane = null;
        [SerializeField] Camera camera = null;

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
            }

            if (Input.GetKeyDown(throwCube) && currCube != null)
            {
                ThrowCube();
            }
        }
        void CreateCube()
        {
            Vector3 diff = new Vector3(0.0f, crane.transform.localScale.y / 2.0f, 0.0f);
            currCube = cubeCreator.CreateCube(crane.transform.position - diff);

            MoveCamera();
            MoveCrane();

            ca = currCube.GetComponent<CubeActions>();
            ca.SetConnectedBody(crane);
            ca.Push(FORCE_INTENSITY.NORMAL);
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
}
