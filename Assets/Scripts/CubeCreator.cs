using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CubeCreator : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab = null;


    void Awake()
    {

    }

    void Update()
    {

    }

    public GameObject CreateCube(Vector3 position)
    {
        GameObject currCube = Instantiate(cubePrefab);
        currCube.transform.position = position;

        return currCube;
    }
}
