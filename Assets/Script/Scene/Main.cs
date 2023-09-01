using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : BaseScene
{
    public override void Clear()
    {
    }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Main;
        Managers.Sound.Play("Sounds/SFX/Start_Voice_3");
        Managers.Sound.PlayDelayed("Sounds/BGM/MainBGM_Edit", 2.3f, Define.Sound.BGM);
        Managers.UI.ShowSceneUI<UI_Main>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
