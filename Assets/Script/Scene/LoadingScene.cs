using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : BaseScene
{
    public override void Clear()
    {
    }

    // Start is called before the first frame update
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.LoadingScene;
        Managers.UI.ShowSceneUI<UI_Loading>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
