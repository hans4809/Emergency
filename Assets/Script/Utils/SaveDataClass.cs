using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[System.Serializable]
public class SaveDataClass
{
    public InGameData InGameData;

    public SaveDataClass()
    {
        InGameData = new InGameData();
    }

    public SaveDataClass(InGameData InGameData)
    {
        this.InGameData = InGameData;
    }
}

public class InGameData
{
    public int Level; // 1, 2, 3 ( 이지 노말 하드 )

    public InGameData()
    {
        Level = 1;
    }

    public InGameData(int Level)
    {
        this.Level = Level;
    }
}

