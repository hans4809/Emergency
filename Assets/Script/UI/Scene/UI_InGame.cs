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
    public float currentTime = 0f;
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
        switch (DataManager.Single.Data.InGameData.Level)
        {
            case 1:
                MaxScore.text = $"{Math.Round(DataManager.Single.Data.InGameData.Score1, 2)}";
                break;
            case 2:
                MaxScore.text = $"{Math.Round(DataManager.Single.Data.InGameData.Score2, 2)}";
                break;
            case 3:
                MaxScore.text = $"{Math.Round(DataManager.Single.Data.InGameData.Score3, 2)}";
                break;
        }
        TimerText.text = $"{Math.Round(currentTime, 1)}";
    }

    private void PauseClicked(PointerEventData data)
    {
        Time.timeScale = 0f;
        Managers.Sound._audioSources[(int)Define.Sound.BGM].Pause();
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
                switch (DataManager.Single.Data.InGameData.Level)
                {
                    case 1:
                        if(DataManager.Single.Data.InGameData.Score1 > 60)
                        {
                            DataManager.Single.Data.InGameData.Score1 = 60;
                        }
                        break;
                    case 2:
                        if (DataManager.Single.Data.InGameData.Score2 > 60)
                        {
                            DataManager.Single.Data.InGameData.Score2 = 60;
                        }
                        break;
                    case 3:
                        if (DataManager.Single.Data.InGameData.Score3 > 60)
                        {
                            DataManager.Single.Data.InGameData.Score3 = 60;
                        }
                        break;
                }
                DataManager.Single.Save();
                Managers.Sound.Stop(Managers.Sound._audioSources[(int)Define.Sound.BGM]);
                Managers.Sound.Play("Sounds/SFX/GameOver_Edit");
                uI_Ending = Managers.UI.ShowPopUpUI<UI_Ending>();
            }
        }
        if (currentTime >= 50)
        {
            Managers.Sound.Play("Sounds/SFX/TimeOut10_Edit");
        }
        Timer.fillAmount = currentTime / 60;
    }
}
