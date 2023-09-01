using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UI_Setting;

public class UI_GamePause : UI_Popup
{
    public enum Buttons
    {
        Resume,
        Main
    }
    public enum Sliders
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
        Bind<GameObject>(typeof(Sliders));
        MasterSlider = Get<GameObject>((int)GameObjects.MasterSlider).GetComponent<Slider>();
        JoyStickSlider = Get<GameObject>((int)GameObjects.JoyStickSlider).GetComponent<Slider>();
        GetButton((int)Buttons.Resume).gameObject.AddUIEvent(ResumeClicked);
        GetButton((int)Buttons.Main).gameObject.AddUIEvent(MainClicked);
        MasterSlider = Get<GameObject>((int)GameObjects.MasterSlider).GetComponent<Slider>();
        MasterSlider.gameObject.AddUIEvent(BGMVolume, Define.UIEvent.Drag);
        MasterSlider.value = DataManager.Single.SoundData.masterVolume;
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
        VolumeText.text = $"{Math.Round(MasterSlider.value, 2) * 100}%";
        JoyStickText.text = $"{Math.Round(JoyStickSlider.value, 2) * 100}%";
    }
    public void ResumeClicked(PointerEventData eventData)
    {
        GameObject.Find("UI_Joystick").GetComponent<UI_Joystick>().SetJoystickSize();
        Time.timeScale = 1;
        ClosePopUPUI();
    }
    public void MainClicked(PointerEventData eventData)
    {
        Time.timeScale = 1;
        Managers.Scene.LoadScene(Define.Scene.Main);
    }
    public void BGMVolume(PointerEventData data)
    {
        DataManager.Single.SoundData.masterVolume = MasterSlider.value;
        if (DataManager.Single.SoundData.masterVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("Master", -80);
        }
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
        VolumeText.text = $"{Math.Round(MasterSlider.value, 2) * 100}%";
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
        JoyStickText.text = $"{Math.Round(JoyStickSlider.value, 2) * 100}%";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
