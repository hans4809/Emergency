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
        Close
    }
    public enum GameObjects
    {
        BGMSlider,
        SFXSlider
    }
    private Slider BGMSlider;
    private Slider SFXSlider;
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
        GetButton((int)Buttons.Close);
        BGMSlider = Get<GameObject>((int)GameObjects.BGMSlider).GetComponent<Slider>();
        SFXSlider = Get<GameObject>((int)GameObjects.SFXSlider).GetComponent<Slider>();
        BGMSlider.gameObject.AddUIEvent(BGMVolume , Define.UIEvent.Drag);
        SFXSlider.gameObject.AddUIEvent(SFXVolume , Define.UIEvent.Drag);
    }
    public void BGMVolume(PointerEventData data)
    {
        //DataManager.singleTon.saveData._bgmVolume = _bgmSlider.value;
        //DataManager.singleTon.jsonManager.Save<DataDefine.SaveData>(DataManager.singleTon.saveData);
        //if (DataManager.singleTon.saveData._bgmVolume <= -40f)
        //{
        //    Managers.Sound.audioMixer.SetFloat("BGM", -80);
        //}
        //Managers.Sound.audioMixer.SetFloat("BGM", Mathf.Log10(_bgmSlider.value) * 20);
        //Managers.Sound._audioSources[(int)Define.Sound.BGM].volume = _sfxSlider.value;
    }
    public void SFXVolume(PointerEventData data)
    {
        //DataManager.singleTon.saveData._sfxVolume = _sfxSlider.value;
        //DataManager.singleTon.jsonManager.Save<DataDefine.SaveData>(DataManager.singleTon.saveData);
        //if (DataManager.singleTon.saveData._bgmVolume <= -40f)
        //{
        //    Managers.Sound.audioMixer.SetFloat("SFX", -80);
        //}
        //Managers.Sound.audioMixer.SetFloat("SFX", Mathf.Log10(_sfxSlider.value) * 20);
        //Managers.Sound._audioSources[(int)Define.Sound.SFX].volume = _sfxSlider.value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
