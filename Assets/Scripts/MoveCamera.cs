using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Vector3 moveVector = new Vector3(0, 0, 0);
    public float speed = 2f;
    public float desiredHeight = 5f;
    private Vector3 curPos;
    private Vector3 rotateValue = new Vector3(0, 0, 0);
    //May delete: private Rigidbody rb;

    private void Start()
    {
        curPos = transform.position;
        curPos.y = Terrain.activeTerrain.SampleHeight(transform.position) + desiredHeight;
        transform.position = curPos;
        
        //May delete: rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0))
        {
            rotateValue.x = -1 * Input.GetAxis("Mouse Y");
            rotateValue.y = Input.GetAxis("Mouse X");
            transform.eulerAngles += rotateValue;
        }
       
        if (moveVector.x != 0 || moveVector.z != 0)
        {
            //May delete: rb.position += moveVector * speed * Time.deltaTime;
            
            transform.position += speed * moveVector * Time.deltaTime;
            curPos = transform.position;
            curPos.y = Terrain.activeTerrain.SampleHeight(transform.position);
            curPos.y += desiredHeight;
            transform.position = curPos;
        }

    }
}
