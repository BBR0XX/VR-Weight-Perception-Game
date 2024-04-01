using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void WriteToFile(string result, int count, string fileName)
    {
        result = result + "Count: " + count;
        DateTime currentDate = DateTime.Now;
        string formattedDate = currentDate.ToString("yyyy-MM-dd-HH-mm");
        string filePath;
        if (GameConfiguration.CDRatio == false ){
            filePath = Application.persistentDataPath + "/" + fileName + "_OFF"  + formattedDate + ".txt";
        }
        else {
            filePath = Application.persistentDataPath + "/" + fileName + "_ON" + formattedDate + ".txt";
        }
        File.WriteAllText(filePath, result);
   }
}
