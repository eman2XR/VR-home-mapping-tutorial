using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour
{
    public Transform handMarker;  //the cube on the hand
    public Transform fixedMarker; //the fixed cube

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One)) //detect is button 'A' has been pressed
        {
            Vector3 posOffset = fixedMarker.position - handMarker.position; //calculate the difference in positions
            this.transform.position += posOffset; //offset the position of the cameraRig to realign the cubes

            Vector3 rotOffset = fixedMarker.eulerAngles - handMarker.eulerAngles; //calculate the difference in rotations
            transform.RotateAround(handMarker.position, Vector3.up, rotOffset.y); //using the hand as a pivot, rotate around Y
        }
    }
}
   
