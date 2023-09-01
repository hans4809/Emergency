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
    float power;

    public enum Buttons
    {
        joystick
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
        power = 0;

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
        direction = GetButton((int)Buttons.joystick).gameObject.transform.position - GetButton((int)Buttons.joystick).transform.parent.transform.position;
        direction.z = 0;
        direction = direction.normalized;
        power = 3;

        player.SetPlayerSpeedAndDirection(power, direction);
    }

    // Update is called once per frame
    void Update()
    {
        joystickAction?.Invoke();
    }
}
