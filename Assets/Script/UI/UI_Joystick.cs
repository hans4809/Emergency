using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Joystick : UI_Scene
{
    Vector3 mousePos;
    Action joystickAction;
    Player player;

    Vector3 direction;
    float speed;
    float distance;

    public enum Buttons
    {
        joystick
    }

    public enum Images
    {
        joyStickBG
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
        GetButton((int)Buttons.joystick).gameObject.AddUIEvent(StickClickStart, Define.UIEvent.PointerDown);
        GetButton((int)Buttons.joystick).gameObject.AddUIEvent(StickClickEnd, Define.UIEvent.PointerUP);
        GetButton((int)Buttons.joystick).gameObject.AddUIEvent(Drag, Define.UIEvent.Drag);

        player = GameObject.Find("Player").GetOrAddComponent<Player>();

        DataManager.Single.Data.InGameData.JoysticSize = 2;
        SetJoystickSize();
    }

    private void StickClickStart(PointerEventData data)
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, -Input.mousePosition.z));
        mousePos.z = 0;
        GetButton((int)Buttons.joystick).gameObject.transform.position = mousePos;

        SetSpeedAndDirection();
        player.MoveStart();
    }

    private void StickClickEnd(PointerEventData data)
    {
        direction = Vector3.zero;
        speed = 0;

        GetButton((int)Buttons.joystick).gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

        player.MoveEnd();
    }

    private void Drag(PointerEventData data)
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, -Input.mousePosition.z));
        mousePos.z = 0;
        GetButton((int)Buttons.joystick).gameObject.transform.position = mousePos;

        SetSpeedAndDirection();
    }

    private void SetSpeedAndDirection()
    {
        direction = GetButton((int)Buttons.joystick).gameObject.transform.position - GetImage((int)Images.joyStickBG).transform.position;
        direction.z = 0;
        distance = Vector3.Distance(GetButton((int)Buttons.joystick).gameObject.transform.position, GetImage((int)Images.joyStickBG).transform.position);
        direction = direction.normalized;

        speed = distance;//GetImage((int)Images.joyStickBG).rectTransform.rect.width;

        player.SetPlayerSpeedAndDirection(speed, direction);
    }

    private void SetJoystickSize()
    {
        Debug.Log(DataManager.Single.Data.InGameData.JoysticSize);
        GetImage((int)Images.joyStickBG).transform.localScale = new Vector3(DataManager.Single.Data.InGameData.JoysticSize, DataManager.Single.Data.InGameData.JoysticSize, 1);
    }

    // Update is called once per frame
    void Update()
    {
        joystickAction?.Invoke();
    }
}
