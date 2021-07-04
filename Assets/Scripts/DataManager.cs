using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    string pathSstatsBallFile = "CSV File/StatsBall";
    public TextAsset statsBallFile;

    private List<string[]> statsBalls = new List<string[]>();

    void Awake()
    {
        Instance = this;

        LoadCvsFile();
    }


    void LoadCvsFile()
    {
        statsBallFile = Resources.Load<TextAsset>(pathSstatsBallFile);

        string[] statsBallDataLines = statsBallFile.ToString().Split('\n');

        for (int i = 1; i < statsBallDataLines.Length - 1; i++)
        {
            string[] statsBall = statsBallDataLines[i].ToString().Split(',');

            statsBalls.Add(statsBall);
        }
    }


    public string[] GetStatBall(TypeBall typeBall)
    {
        foreach (string[] statsBall in statsBalls)
        {
            if (statsBall[0] == typeBall.ToString())
            {
                return statsBall;
            }
        }

        return null;
    }
}