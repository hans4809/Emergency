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
        GetButton((int)Buttons.Close).gameObject.AddUIEvent(CloseClicked);
        BGMSlider = Get<GameObject>((int)GameObjects.BGMSlider).GetComponent<Slider>();
        SFXSlider = Get<GameObject>((int)GameObjects.SFXSlider).GetComponent<Slider>();
        BGMSlider.gameObject.AddUIEvent(BGMVolume , Define.UIEvent.Drag);
        SFXSlider.gameObject.AddUIEvent(SFXVolume , Define.UIEvent.Drag);
        BGMSlider.value = Managers.Data.SoundData.bgmVolume;
        Managers.Sound.audioMixer.SetFloat("BGM", Mathf.Log10(BGMSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.BGM].volume = BGMSlider.value;
        SFXSlider.value = Managers.Data.SoundData.sfxVolume;
        Managers.Sound.audioMixer.SetFloat("SFX", Mathf.Log10(SFXSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.SFX].volume = SFXSlider.value;
    }
    public void CloseClicked(PointerEventData data)
    {
        ClosePopUPUI();
    }
    public void BGMVolume(PointerEventData data)
    {
        Managers.Data.SoundData.bgmVolume = BGMSlider.value;
        if (Managers.Data.SoundData.bgmVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("BGM", -80);
        }
        Managers.Sound.audioMixer.SetFloat("BGM", Mathf.Log10(BGMSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.BGM].volume = BGMSlider.value;
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
        Managers.Data.SoundData.sfxVolume = SFXSlider.value;
        if (Managers.Data.SoundData.sfxVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("SFX", -80);
        }
        Managers.Sound.audioMixer.SetFloat("SFX", Mathf.Log10(SFXSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.SFX].volume = SFXSlider.value;
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
