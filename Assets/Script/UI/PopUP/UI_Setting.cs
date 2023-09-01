using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Setting : UI_Popup
{
    public enum Buttons
    {
        Close,
        Credit
    }
    public enum GameObjects
    {
        MasterSlider
    }
    private Slider MasterSlider;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));
        GetButton((int)Buttons.Close).gameObject.AddUIEvent(CloseClicked);
        GetButton((int)Buttons.Credit).gameObject.AddUIEvent(CreditClicked);
        MasterSlider = Get<GameObject>((int)GameObjects.MasterSlider).GetComponent<Slider>();
        MasterSlider.gameObject.AddUIEvent(MasterVolume, Define.UIEvent.Drag);
        MasterSlider.value = DataManager.Single.SoundData.masterVolume;
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
        //Managers.Sound._audioSources[(int)Define.Sound.BGM].volume = MasterSlider.value;
    }
    public void CloseClicked(PointerEventData data)
    {
        ClosePopUPUI();
    }
    public void CreditClicked(PointerEventData data)
    {
        Managers.UI.ShowPopUpUI<UI_Credit>();
    }
    public void MasterVolume(PointerEventData data)
    {
        DataManager.Single.SoundData.masterVolume = MasterSlider.value;
        Debug.Log(DataManager.Single.SoundData.masterVolume);
        if (DataManager.Single.SoundData.masterVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("Master", -80);
        }
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
        //Managers.Sound._audioSources[(int)Define.Sound.BGM].volume = MasterSlider.value;
        //DataManager.singleTon.saveData._bgmVolume = _bgmSlider.value;
        //DataManager.singleTon.jsonManager.Save<DataDefine.SaveData>(DataManager.singleTon.saveData);
        //if (DataManager.singleTon.saveData._bgmVolume <= -40f)
        //{
        //    Managers.Sound.audioMixer.SetFloat("BGM", -80);
        //}
        //Managers.Sound.audioMixer.SetFloat("BGM", Mathf.Log10(_bgmSlider.value) * 20);
        //Managers.Sound._audioSources[(int)Define.Sound.BGM].volume = _sfxSlider.value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
