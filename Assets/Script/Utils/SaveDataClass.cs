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
        this.masterVolume = 1f;
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
    public float Time;

    public InGameData()
    {
        Level = 1;
        JoysticSize = 1.0f;
        Time = 0.0f;
    }

    public InGameData(int Level, float JoysticSize, float Time)
    {
        this.Level = Level;
        this.JoysticSize = JoysticSize;
        this.Time = Time;
    }
}