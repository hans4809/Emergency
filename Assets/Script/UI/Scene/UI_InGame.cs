using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InGame : UI_Scene
{
    public enum Buttons
    {
        Pause
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
        GetButton((int)Buttons.Pause).gameObject.AddUIEvent(PauseClicked);
    }

    private void PauseClicked(PointerEventData data)
    {
        Time.timeScale = 0f;
        Managers.UI.ShowPopUpUI<UI_GamePause>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
