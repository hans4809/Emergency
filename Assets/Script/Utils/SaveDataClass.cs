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

    public SaveDataClass(InGameData InGameData, SoundData soundData)
    {
        this.InGameData = InGameData;
    }
}

public class SoundData
{
    public float masterVolume;
    public SoundData()
    {
        this.masterVolume = 0.5f;
    }
    public SoundData(float masterVolume)
    {
        this.masterVolume = masterVolume;

    }
}

public class InGameData
{
    public int Level; // 1, 2, 3 ( ���� �븻 �ϵ� )
    public float JoysticSize;

    public InGameData()
    {
        Level = 1;
        JoysticSize = 1.0f;
    }

    public InGameData(int Level, float JoysticSize)
    {
        this.Level = Level;
        this.JoysticSize = JoysticSize;
    }
}