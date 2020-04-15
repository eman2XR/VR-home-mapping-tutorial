using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPlacer : MonoBehaviour
{
    OSC osc; //reference to the osc script that will send the network messages

    void Start()
    {
        osc = (OSC)FindObjectOfType(typeof(OSC)); //get the OSC script instance in the scene
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two)) //detect is button 'B' has been pressed
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); //create a cube
            cube.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f); //scale it down
            cube.transform.position = this.transform.position; //move it to the position of our controller

            OscMessage message = new OscMessage(); //create a new message
            message.address = "/newPoint"; //set the message
            message.values.Add(cube.transform.position.x); //add x position
            message.values.Add(cube.transform.position.y); //add y position
            message.values.Add(cube.transform.position.z); //add z position
            osc.Send(message); //send the message
        }
    }
}
