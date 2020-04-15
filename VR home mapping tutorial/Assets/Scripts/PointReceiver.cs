using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointReceiver : MonoBehaviour
{
    OSC osc;        //reference to the osc script that will receive the network messages
    Transform map;  //a holder for the points

    void Start()
    {
        osc = (OSC)FindObjectOfType(typeof(OSC)); //get the OSC script instance in the scene
        osc.SetAddressHandler("/newPoint", OnReceivePoint); //set it to listen to messages with our address

        if (GameObject.Find("Map") == null) //if there's no 'Map' object in the scene
            map = new GameObject().transform; //then create one

        map.gameObject.name = "Generated Map"; //rename it
    }

    void OnReceivePoint(OscMessage message)
    {
        print("received point");
        float x = message.GetFloat(0);
        float y = message.GetFloat(1);
        float z = message.GetFloat(2);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); //create a cuve
        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); //scale it down
        cube.transform.position = new Vector3(x, y, z); //place it at the position received
        cube.transform.parent = map; //parent it to the 'Generated Map' object
    }
}
