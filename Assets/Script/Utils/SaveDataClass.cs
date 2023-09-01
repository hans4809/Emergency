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

[System.Serializable]
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

[System.Serializable]
public class InGameData
{
    public int Level; // 1, 2, 3 ( ���� �븻 �ϵ� )
    public float JoysticSize;
    public float Time;
    public bool IsClear;
    public float Score1;
    public float Score2;
    public float Score3;

    public InGameData()
    {
        Level = 1;
        JoysticSize = 1.0f;
        Time = 0.0f;
        IsClear = false;
        Score1 = 0.0f;
        Score2 = 0.0f;
        Score3 = 0.0f;
    }

    public InGameData(int Level, float JoysticSize, float Time, bool IsClear)
    {
        this.Level = Level;
        this.JoysticSize = JoysticSize;
        this.Time = Time;
        this.IsClear = IsClear;
        Score1 = 0.0f;
        Score2 = 0.0f;
        Score3 = 0.0f;
    }

    public InGameData(int Level, float JoysticSize, float Score1, float Score2, float Score3)
    {
        this.Level = Level;
        this.JoysticSize = JoysticSize;
        this.Score1 = Score1;
        this.Score2 = Score2;
        this.Score3 = Score3;
    }
}