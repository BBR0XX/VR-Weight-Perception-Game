using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWeights : MonoBehaviour
{
    //List of cubes
    public List<GameObject> weights = new List<GameObject>();

    //List of cube positions
    public List<Vector3> weightPositions = new List<Vector3>();

    //Rotation values for cubes
    private Quaternion weightRot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

    //Function to randomise and reset the position of the cubes 
    public void RestartWeight()
    {
        RandomizeWeights(weightPositions);
        SetWeightPositions();
    }

    //Function to randomise the position of the cubes
    public void RandomizeWeights<T>(List<T> weightList)
    {
        for(int i=0; i<weightList.Count -1; i++)
        {
            T temp = weightList[i];
            int randomNum = Random.Range(i, weightList.Count);
            weightList[i] = weightList[randomNum];
            weightList[randomNum] = temp;
        }
    }

    //Function to set the position of the cubes
    public void SetWeightPositions()
    {
        for(int i=0; i<weightPositions.Count; i++)
        {
            weights[i].transform.position = weightPositions[i];
        }
    }

    //Function to set the rotation of the cubes
    public void SetWeightRotation()
    {
        for(int i=0; i<weights.Count; i++)
        {
            weights[i].transform.rotation = weightRot;
        }
    }
}
