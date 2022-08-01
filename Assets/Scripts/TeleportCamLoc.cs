using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCamLoc : MonoBehaviour
{
    public Transform xrRig;
    //public Transform head;
    //public Transform bodyTracker;
    [Header("Press T to teleport to this location")]
    public Transform startPos;
    public float desiredHeight;
    private bool teleported;

    void Start()
    {
        teleported = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)){
            Vector3 tempPos = startPos.position;
            tempPos.y = desiredHeight;
            xrRig.position = tempPos;
            teleported = true;
        }
        
    }

    public bool IsTeleported()
    {
        return teleported;
    }
}
