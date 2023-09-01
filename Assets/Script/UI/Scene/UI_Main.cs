using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Main : UI_Scene
{
    public enum Buttons
    {
        Start,
        Setting,
        Quit
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Start).gameObject.AddUIEvent(StartClicked);
        GetButton((int)Buttons.Setting).gameObject.AddUIEvent(SettingClicked);
        GetButton((int)Buttons.Quit).gameObject.AddUIEvent(QuitClicked);
        if (DataManager.Single.GameToSelect)
        {
            Managers.UI.ShowPopUpUI<UI_Stage>();
        }
    }
    private void StartClicked(PointerEventData data)
    {
        Managers.UI.ShowPopUpUI<UI_Stage>();
    }
    private void SettingClicked(PointerEventData data)
    {
        Managers.UI.ShowPopUpUI<UI_Setting>();
    }
    private void QuitClicked(PointerEventData data)
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
