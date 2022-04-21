using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tower_Bloxx
{
    public enum FORCE_INTENSITY { LOW, NORMAL, HIGH, }


    [RequireComponent(typeof(Material))]
    [RequireComponent(typeof(Rigidbody))]

    public class CubeActions : MonoBehaviour
    {
        [SerializeField] SpringJoint sj1;
        [SerializeField] SpringJoint sj2;

        Material m = null;
        Rigidbody rb = null;


        void Awake()
        {
            m = GetComponent<Material>();
            rb = GetComponent<Rigidbody>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                Freeze();
                ChangeTagToFloor();
            }
        }


        public void SetMaterialColor(Color color)
        {
            m.color = color;
        }
        public void SetConnectedBody(GameObject crane)
        {
            Rigidbody rb = crane.GetComponent<Rigidbody>();

            sj1.connectedBody = rb;
            sj1.connectedAnchor = new Vector3(0.0f, -crane.transform.localScale.y / 2.0f, 0.0f);
            sj1.anchor = new Vector3(-gameObject.transform.localScale.x / 2.0f, gameObject.transform.localScale.y / 2.0f, 0.0f);
            sj1.maxDistance = Vector3.Distance(sj1.connectedAnchor, sj1.anchor);

            sj2.connectedBody = rb;
            sj2.connectedAnchor = new Vector3(0.0f, -crane.transform.localScale.y / 2.0f, 0.0f);
            sj2.anchor = new Vector3(gameObject.transform.localScale.x / 2.0f, gameObject.transform.localScale.y / 2.0f, 0.0f);
            sj2.maxDistance = Vector3.Distance(sj2.connectedAnchor, sj2.anchor);
        }
        public void Push(FORCE_INTENSITY f)
        {
            switch (f)
            {
                case FORCE_INTENSITY.LOW:
                    Vector3 speedForceL = new Vector3(gameObject.transform.localScale.x * 15.0f, 0.0f, 0.0f);
                    rb.AddForce(speedForceL);
                    break;

                case FORCE_INTENSITY.NORMAL:
                    Vector3 speedForceN = new Vector3(gameObject.transform.localScale.x * 30.0f, 0.0f, 0.0f);
                    rb.AddForce(speedForceN);
                    break;

                case FORCE_INTENSITY.HIGH:
                    Vector3 speedForceH = new Vector3(gameObject.transform.localScale.x * 50.0f, 0.0f, 0.0f);
                    rb.AddForce(speedForceH);
                    break;
            }
        }
        public void Throw()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            Destroy(sj1);
            Destroy(sj2);
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
}
