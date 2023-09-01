using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[System.Serializable]
public class SaveDataClass
{
    public InGameData InGameData;
    public SoundData soundData;

    public SaveDataClass()
    {
        InGameData = new InGameData();
        soundData = new SoundData();
    }

    public SaveDataClass(InGameData InGameData, SoundData soundData)
    {
        this.InGameData = InGameData;
        this.soundData = soundData;
    }
}

public class SoundData
{
    public float bgmVolume;
    public float sfxVolume;
    public SoundData()
    {
        this.bgmVolume = 0.5f;
        this.sfxVolume = 0.5f;
    }
    public SoundData(float bgmVolume, float sfxVolume)
    {
        this.bgmVolume = bgmVolume;
        this.sfxVolume = sfxVolume;
    }
}

public class InGameData
{
    public int Level; // 1, 2, 3 ( ���� �븻 �ϵ� )

    public InGameData()
    {
        Level = 1;
    }

    public InGameData(int Level)
    {
        this.Level = Level;
    }
}