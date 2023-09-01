using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UI_Setting;

public class UI_GamePause : UI_Popup
{
    public enum Buttons
    {
        Resume,
        Quit,
        Main
    }
    public enum Sliders
    {
        MasterSlider,
        SFXSlider
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
        GetButton((int)Buttons.Resume).gameObject.AddUIEvent(ResumeClicked);
        GetButton((int)Buttons.Quit).gameObject.AddUIEvent(QuitClicked);
        GetButton((int)Buttons.Main).gameObject.AddUIEvent(MainClicked);
        MasterSlider = Get<GameObject>((int)GameObjects.MasterSlider).GetComponent<Slider>();
        MasterSlider.gameObject.AddUIEvent(BGMVolume, Define.UIEvent.Drag);
        MasterSlider.value = Managers.Data.SoundData.masterVolume;
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.Master].volume = MasterSlider.value;
    }
    public void ResumeClicked(PointerEventData eventData)
    {
        Time.timeScale = 1;
        ClosePopUPUI();
    }
    public void QuitClicked(PointerEventData eventData) 
    {
        Time.timeScale = 1;
        Managers.Data.GameToSelect = true;
        Managers.Scene.LoadScene(Define.Scene.Main);
    }
    public void MainClicked(PointerEventData eventData)
    {
        Time.timeScale = 1;
        Managers.Scene.LoadScene(Define.Scene.Main);
    }
    public void BGMVolume(PointerEventData data)
    {
        Managers.Data.SoundData.masterVolume = MasterSlider.value;
        if (Managers.Data.SoundData.masterVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("Master", -80);
        }
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(MasterSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.Master].volume = MasterSlider.value;
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
