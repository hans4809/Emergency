using System.Collections;
using System.Collections.Generic;
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
    public enum Images
    {
        Test
    }
    public Image Test;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        GetButton((int)Buttons.Stage1).gameObject.AddUIEvent(Stage1);
        GetButton((int)Buttons.Stage2).gameObject.AddUIEvent(Stage2);
        GetButton((int)Buttons.Stage3).gameObject.AddUIEvent(Stage3);
        GetButton((int)Buttons.Back).gameObject.AddUIEvent(Back);
    }
    private void Stage1(PointerEventData data)
    {
        DataManager.Single.Data.InGameData.Level = 1;
        Managers.Sound.Play("Sounds/SFX/StageSelect");
        Managers.UI.ShowPopUpUI<UI_Loading>();
    }
    private void Stage2(PointerEventData data)
    {
        DataManager.Single.Data.InGameData.Level = 2;
        Managers.Sound.Play("Sounds/SFX/StageSelect");
        Managers.UI.ShowPopUpUI<UI_Loading>();
    }
    private void Stage3(PointerEventData data)
    {
        DataManager.Single.Data.InGameData.Level = 3;
        Managers.Sound.Play("Sounds/SFX/StageSelect");
        Managers.UI.ShowPopUpUI<UI_Loading>();
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
