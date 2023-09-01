using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
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
        MasterSlider,
        JoyStickSlider
    }
    private Slider MasterSlider;
    private Slider JoyStickSlider;
    [SerializeField] private TMP_Text VolumeText;
    [SerializeField] private TMP_Text JoyStickText;
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
        JoyStickSlider = Get<GameObject>((int)GameObjects.JoyStickSlider).GetComponent<Slider>();
        MasterSlider.gameObject.AddUIEvent(MasterVolume, Define.UIEvent.Drag);
        JoyStickSlider.gameObject.AddUIEvent(JoyStickSize, Define.UIEvent.Drag);
        MasterSlider.value = DataManager.Single.SoundData.masterVolume;
        JoyStickSlider.value = DataManager.Single.UIData.JoyStickSize;
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
        JoyStickText.text = $"{Math.Round(JoyStickSlider.value, 2) * 100}%";
        VolumeText.text = $"{Math.Round(MasterSlider.value, 2) * 100}%";
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
        if (DataManager.Single.SoundData.masterVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("Master", -80);
        }
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
        VolumeText.text = $"{Math.Round(MasterSlider.value, 2) * 100}%";
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
    public void JoyStickSize(PointerEventData data)
    {
        DataManager.Single.Data.InGameData.JoysticSize = JoyStickSlider.value;
        DataManager.Single.UIData.JoyStickSize = JoyStickSlider.value;
        Debug.Log(DataManager.Single.UIData.JoyStickSize);
        JoyStickText.text = $"{Math.Round(JoyStickSlider.value, 2) * 100}%";
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
