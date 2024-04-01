using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrangeCubes: MonoBehaviour
{
    public ResetWeights resetWeights;

    //Colliders for the boxes
    public List<CheckCube> colliders = new List<CheckCube>();

    //Cubes 
    public List<string> cubes = new List<string>();
    
    //Game screens
    public GameObject mainScreen, incorrectScreen, successScreen;

    //Playthrough data 
    private string result  = "";

    //Attempt count 
    private int count = 0;

    void Start()
    {
        //Randomise positions of the cubes when application starts 
        // RestartPuzzle();
    }

    //Function to check the arrangement of the cubes
    public void CheckArrangement()
    {
        for(int i=0; i<colliders.Count; i++)
        {
            cubes.Add(colliders[i].objectName);
        }
        //Create data
        result = result + string.Join(", ", cubes) +"\n";
        count += 1;
        cubes.Clear();

        int allCorrect = 0;

        foreach(CheckCube collider in colliders)
        {
            //If a wrong cube is placed
            if(collider.currentObject == false)
            {
                //Show incorrect screen
                mainScreen.SetActive(false);
                incorrectScreen.SetActive(true);
                successScreen.SetActive(false);
                break;
            }
            else 
            {
                allCorrect++;
            }
        }
        //If all cubes are correct
        if (allCorrect == 4)
        {
            //Show success screen
            mainScreen.SetActive(false);
            incorrectScreen.SetActive(false);
            successScreen.SetActive(true);
            //Record playthrough
            Record();
        }

    }

    //Function to record the playthrough into a text file 
    public void Record()
    {
        GameManager.WriteToFile(result, count, "Survey_AC");
        result = "";
        count = 0;
    }
  
    //Function to restart the game
    public void RestartPuzzle()
    {
        resetWeights.RestartWeight();
        resetWeights.SetWeightRotation();
        ActivateMainScreen();
        result = "";
        count = 0;
    }

    //Function to reset the position of the cubes
    public void ResetWeightPosition()
    {
        resetWeights.SetWeightPositions();
        resetWeights.SetWeightRotation();
        ActivateMainScreen();
    }

    //Function to activate the main screen
    public void ActivateMainScreen()
    {
        mainScreen.SetActive(true);
        incorrectScreen.SetActive(false);
        successScreen.SetActive(false);
    }
}
