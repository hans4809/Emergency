using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    JsonManager jsonManager; // json���� ���� �о���ų� �����ϴ� JsonManager
    public SaveDataClass Data; // �����͸� �����ϴ� ������ SaveDataClass
    public SoundData SoundData;
    void Awake()
    {
        Data = new SaveDataClass();
        jsonManager = new JsonManager();
        SoundData = new SoundData();
        Load();
    }
    public void Init()
    {
        Data = new SaveDataClass();
        jsonManager = new JsonManager();
        SoundData = new SoundData(0.5f, 0.5f);
        Load();
    }
    public void Save() // saveData�� ��ϵ� �����͵��� json�� �����Ѵ�
    {
        jsonManager.SaveJson(Data);
    }

    public void Load() // json�� ��ϵ��ִ� �����͵��� �ҷ��´�
    {
        Data = jsonManager.LoadSaveData();
    }
}