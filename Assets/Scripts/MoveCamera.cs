using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Vector3 moveVector = new Vector3(0, 0, 0);
    public float speed = 2f;
    private Vector3 rotateValue = new Vector3(0, 0, 0);

    private void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
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
            transform.position += speed * moveVector * Time.deltaTime;
        }

    }
}
