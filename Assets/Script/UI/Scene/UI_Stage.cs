using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stage : UI_Scene
{
    public enum Buttons
    {
        Stage1,
        Stage2,
        Stage3
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Stage1);
        GetButton((int)Buttons.Stage2);
        GetButton((int)Buttons.Stage3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
