using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Single;
    JsonManager jsonManager; // json���� ���� �о���ų� �����ϴ� JsonManager
    public SaveDataClass Data; // �����͸� �����ϴ� ������ SaveDataClass
    public SoundData SoundData;
    public UIData UIData;
    public bool GameToSelect;
    void Awake()
    {
        GameObject go = GameObject.Find("@Data");
        if (go == null)
        {
            go = new GameObject { name = "@Data" };
            go.AddComponent<DataManager>();
        }
        DontDestroyOnLoad(go);
        Single = go.GetComponent<DataManager>();

        //s_instance._sound.Init();

        Data = new SaveDataClass();
        jsonManager = new JsonManager();
        SoundData = new SoundData();
        UIData = new UIData();
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

public class UIData
{
    public bool GameToSelect = false;
    public float JoyStickSize = 1f;
}