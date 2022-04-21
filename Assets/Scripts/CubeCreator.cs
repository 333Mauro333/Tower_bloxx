using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Tower_Bloxx
{
    public class CubeCreator : MonoBehaviour
    {
        [SerializeField] GameObject cubePrefab = null;


        public GameObject CreateCube(Vector3 position)
        {
            Vector3 diff;

            GameObject currCube = Instantiate(cubePrefab);
            diff = new Vector3(0.0f, currCube.transform.localScale.y / 2.0f, 0.0f);

            currCube.transform.position = position - diff;

            return currCube;
        }
    }
}
