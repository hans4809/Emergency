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
    public enum Texts
    {
        StageText,
        MaxScore,
        TimerText
    }
    public enum Images
    {
        Timer
    }
    [SerializeField]Text StageText;
    [SerializeField]Text MaxScore;
    [SerializeField]Text TimerText;
    [SerializeField]Image Timer;
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
        GetButton((int)Buttons.Pause).gameObject.AddUIEvent(PauseClicked);
        Timer = GetImage((int)Images.Timer);
        StageText.text = $"{DataManager.Single.Data.InGameData.Level}";
        MaxScore.text = $"{Math.Round(DataManager.Single.Data.InGameData.Time, 1)}";
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
