using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Oculus.Interaction;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using System.IO;
using Unity.VisualScripting.Dependencies.NCalc;


public class BalanceScale: GameManager
{
    public ResetWeights resetWeights;

    //Balance scale objects
    public GameObject mainPivot, leftPivot, rightPivot, leftBoxPivot, rightBoxPivot;

    //Rotation values for main pivot
    private Quaternion mainPivotRot;

    //Position values for other pivots
    private Vector3 leftPivotPos, rightPivotPos, leftBoxPivotPos, rightBoxPivotPos;

    //Rigidbodies of scale objects
    private Rigidbody mainRb, leftRb, rightRb, leftBoxRb, rightBoxRb;
    
    //Game screens
    public GameObject mainScreen, incorrectScreen, successScreen;

    //Left & right container collider
    public Collider leftCollider, rightCollider;

    //Playthrough data
    private string result  = "";

     //Attempt count 
    private int count = 0;

    void Start()
    {
        //Randomise positions of the cubes when application starts 
        // RestartPuzzle();
    }
    
    void Awake()
    {
        //Get position for scale objects
        mainPivotRot = mainPivot.transform.rotation;
        leftPivotPos = leftPivot.transform.position;
        rightPivotPos = rightPivot.transform.position;
        leftBoxPivotPos = leftBoxPivot.transform.position;
        rightBoxPivotPos = rightBoxPivot.transform.position;

        //Get rigidbody of scale objects
        mainRb = mainPivot.GetComponent<Rigidbody>();
        leftRb = leftPivot.GetComponent<Rigidbody>();
        rightRb = rightPivot.GetComponent<Rigidbody>();
        leftBoxRb = leftBoxPivot.GetComponent<Rigidbody>();
        rightBoxRb = rightBoxPivot.GetComponent<Rigidbody>();
    }

    //Function to reset the scale
    public void ResetScale()
    {
        //Reset position of pivots
        SetPivots();

        //Reset position of weights
        resetWeights.SetWeightPositions();

        //Set rotation fo weights
        resetWeights.SetWeightRotation();

        //Set kinematic of scale objets to true
        SetKinematic(true);

        //Activate main screen
        ActivateMainScreen();
    }

    //Function to activate the scale
    public void ActivateScale()
    {
        //Set kinematic of scale objets to false
        SetKinematic(false);

        //Compare the total weight of both sides of the scale
        CheckBalance();
    }

    //Function to restart the game
    public void RestartPuzzle()
    {
        //Reset position of scale objects
        SetPivots();

        //Restart position of weights
        resetWeights.RestartWeight();

        //Set rotation of weights
        resetWeights.SetWeightRotation();

        //Set kinematic of scale objets to true
        SetKinematic(true);

        //Activate main screen
        ActivateMainScreen();

        result = "";
        count = 0;
    }

    //Function to check the balance of the scale
    public void CheckBalance()
    {
        int leftSum = leftCollider.GetComponent<CheckWeight>().sum;
        int rightSum = rightCollider.GetComponent<CheckWeight>().sum;

        //Creating data
        result = result + "Left: " + leftSum + " Right: " + rightSum +"\n";
        count += 1;

        //If the total weight of each side is not equal zero
        if(leftSum != 0 && rightSum != 0)
        {
            //If the total weight of each side is equal
            if(leftSum == rightSum)
            {
                //Show success screen
                SetScreen(false);
                //Record playthrough
                Record();
            }
            //If the total weight of each side is not equal
            else if(leftSum != rightSum)
            {
                //Show incorrect screen
                SetScreen(true);
            }
        } 
        else 
        {
            //Show incorrect screen
            SetScreen(true);
        }
        
    }

    //Function to set the scale to be kinematic or not
    public void SetKinematic(bool active)
    {
        mainRb.isKinematic = active;
        leftRb.isKinematic = active;
        rightRb.isKinematic = active;
        leftBoxRb.isKinematic = active;
        rightBoxRb.isKinematic = active;
    }

    //Function to activate the main game screen
    public void ActivateMainScreen()
    {
        mainScreen.SetActive(true);
        incorrectScreen.SetActive(false);
        successScreen.SetActive(false);
    }

    //Function to activate the incorrect and success screens
    public void SetScreen(bool status)
    {
        mainScreen.SetActive(false);
        incorrectScreen.SetActive(status);
        successScreen.SetActive(!status);
    }

    //Function to set the pivots of the scale    
    public void SetPivots()
    {
        mainPivot.transform.rotation = mainPivotRot;
        leftPivot.transform.position = leftPivotPos;
        rightPivot.transform.position = rightPivotPos;
        leftBoxPivot.transform.position = leftBoxPivotPos;
        rightBoxPivot.transform.position = rightBoxPivotPos;
    }

    //Function to record the playthrough into a text file
    public void Record()
    {
        GameManager.WriteToFile(result, count, "Survey_BC");
        result = "";
        count = 0;
    }
}
