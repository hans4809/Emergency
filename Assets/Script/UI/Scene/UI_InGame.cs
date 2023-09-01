using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InGame : UI_Scene
{
    public enum Buttons
    {
        Pause
    }
    public enum Images
    {
        Timer
    }
    [SerializeField]TMP_Text StageText;
    [SerializeField]TMP_Text MaxScore;
    [SerializeField]TMP_Text TimerText;
    [SerializeField]Image Timer;
    float currentTime = 0f;
    [SerializeField] UI_Ending uI_Ending;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        DataManager.Single.Data.InGameData.IsClear = false;
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        GetButton((int)Buttons.Pause).gameObject.AddUIEvent(PauseClicked);
        Timer = GetImage((int)Images.Timer);
        StageText.text = $"{DataManager.Single.Data.InGameData.Level}";
        MaxScore.text = $"{Math.Round(DataManager.Single.Data.InGameData.Time, 1)}";
        TimerText.text = $"{Math.Round(currentTime, 1)}";
    }

    private void PauseClicked(PointerEventData data)
    {
        Time.timeScale = 0f;
        Managers.UI.ShowPopUpUI<UI_GamePause>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DataManager.Single.Data.InGameData.IsClear)
        {
            return;
        }

        if (currentTime <= 60)
        {
            currentTime += 1 * Time.deltaTime;
            TimerText.text = $"{Math.Round(currentTime, 1)}";
        }
        else
        {
            if (uI_Ending == null)
            {
                Managers.Sound.Stop(Managers.Sound._audioSources[(int)Define.Sound.BGM]);
                Managers.Sound.Play("Sounds/SFX/GameOver");
                uI_Ending = Managers.UI.ShowPopUpUI<UI_Ending>();
            }
        }
        if (currentTime >= 50)
        {
            Managers.Sound.Play("Sounds/SFX/TimeOut10");
        }
        Timer.fillAmount = currentTime / 60;
    }
}
