using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Stage : UI_Popup
{
    public enum Buttons
    {
        Stage1,
        Stage2,
        Stage3,
        Back
    }
    public TMP_Text score1;
    public TMP_Text score2;
    public TMP_Text score3;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Stage1).gameObject.AddUIEvent(Stage1);
        GetButton((int)Buttons.Stage2).gameObject.AddUIEvent(Stage2);
        GetButton((int)Buttons.Stage3).gameObject.AddUIEvent(Stage3);
        GetButton((int)Buttons.Back).gameObject.AddUIEvent(Back);
        score1.text = $"{Math.Round(DataManager.Single.Data.InGameData.Score1, 2)}";
        score2.text = $"{Math.Round(DataManager.Single.Data.InGameData.Score2, 2)}";
        score3.text = $"{Math.Round(DataManager.Single.Data.InGameData.Score3, 2)}";
    }
    private void Stage1(PointerEventData data)
    {
        DataManager.Single.Data.InGameData.Level = 1;
        Managers.Sound.Play("Sounds/SFX/StageSelect");
        Managers.Scene.LoadScene(Define.Scene.LoadingScene);
    }
    private void Stage2(PointerEventData data)
    {
        DataManager.Single.Data.InGameData.Level = 2;
        Managers.Sound.Play("Sounds/SFX/StageSelect");
        Managers.Scene.LoadScene(Define.Scene.LoadingScene);
    }
    private void Stage3(PointerEventData data)
    {
        DataManager.Single.Data.InGameData.Level = 3;
        Managers.Sound.Play("Sounds/SFX/StageSelect");
        Managers.Scene.LoadScene(Define.Scene.LoadingScene);
    }
    private void Back(PointerEventData data)
    {
        ClosePopUPUI();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
