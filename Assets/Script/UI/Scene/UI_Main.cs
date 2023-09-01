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
    public enum Texts
    {
        TimerText
    }
    public enum Images
    {
        Timer
    }
    [SerializeField] Text TimerText;
    [SerializeField] Image Timer;
    float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        GetButton((int)Buttons.Start).gameObject.AddUIEvent(StartClicked);
        GetButton((int)Buttons.Setting).gameObject.AddUIEvent(SettingClicked);
        GetButton((int)Buttons.Quit).gameObject.AddUIEvent(QuitClicked);
        Timer = GetImage((int)Images.Timer);
        TimerText.text = $"{Math.Round(currentTime, 1)}";
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
        if (currentTime <= 60)
        {
            currentTime += 1 * Time.deltaTime;
            TimerText.text = $"{Math.Round(currentTime, 1)}";
        }
        else
        {
            //To Do 게임오버
        }
        Timer.fillAmount = currentTime / 60;
    }
}
