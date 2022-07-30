using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VarjoExample
{
    public class Locomotion : MonoBehaviour
    {
        Controller controller;
        public Transform xrRig;
        public Transform head;
        public Transform bodyTracker;
        [Header("Use controller.primaryButton to move")]
        public float moveSpeed;
        [Header("set Cam height")]
        public float desiredHeight;
        private Vector3 tempPos;

        // Start is called before the first frame update
        void Start()
        {   
            controller = GetComponent<Controller>();
            /*Vector3 tempPos = startPos.position;
            tempPos.y = desiredHeight;
            xrRig.position = tempPos;*/
        }

        // Update is called once per frame
        void Update()
        {
            if (controller.primaryButton)
            {
                tempPos = xrRig.position;
                tempPos.y = desiredHeight;
                xrRig.position = tempPos;

                // Head-based steering
                //xrRig.transform.Translate(VectorYToZero(head.forward) * moveSpeed * Time.deltaTime, Space.World);
                
                // Body-based steering (Body rotation is tracked by a Vive Tracker)
                xrRig.transform.Translate(ProjectToXZPlane(bodyTracker.forward) * moveSpeed * Time.deltaTime, Space.World);

            }

        }

        Vector3 ProjectToXZPlane(Vector3 v)
        {
            return new Vector3(v.x, 0.0f, v.z).normalized;
            // for the specific projection to x-z plane, simply setting y to 0 works.
        }
    }
}
