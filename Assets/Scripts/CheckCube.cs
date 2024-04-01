using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCube : MonoBehaviour
{
    public string correctObject;
    public bool currentObject;
    public string objectName;

    //When cube is placed into the box
    public void OnTriggerEnter(Collider other)
    {
        objectName = other.gameObject.name;  

        //If cube is correct
        if(objectName == correctObject)
        {
            currentObject = true;
        }
        //If cube is incorrect
        else 
        {
            currentObject = false;
        }
    }

    //When cube is removed from the box
    public void OnTriggerExit(Collider other)
    {
        //Set cube to null
        objectName = "Null";
        currentObject = false;        
    }
}
