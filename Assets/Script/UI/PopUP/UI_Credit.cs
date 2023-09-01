using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UI_Credit : UI_Popup
{
    public enum Buttons
    {
        Close
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
        GetButton((int)Buttons.Close).gameObject.AddUIEvent(CloseClicked);
    }
    public void CloseClicked(PointerEventData eventData)
    {
        ClosePopUPUI();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
