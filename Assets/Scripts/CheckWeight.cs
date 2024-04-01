using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWeight : MonoBehaviour
{
    public int sum = 0;

    //When cube is placed into the box
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Cube")){
            //Add weight of cube to total weight
            sum += other.gameObject.GetComponent<ForceManager>().weight;
        }     
    }

    //When cube is removed from the box
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Cube")){
            //Subtract weight of cube from total weight
            sum -= other.gameObject.GetComponent<ForceManager>().weight;
        } 
    }
}
