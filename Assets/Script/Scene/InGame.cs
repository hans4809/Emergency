using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : BaseScene
{
    [SerializeField] UI_Joystick joystick;
    // Start is called before the first frame update
    public override void Clear()
    {
    }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.InGame;
        Managers.Sound.Play("Sounds/BGM/GameBGM", Define.Sound.BGM);
        Managers.UI.ShowSceneUI<UI_InGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
