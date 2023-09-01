using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControllerEX : BaseController
{
    [SerializeField] VariableJoystick joystick;
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] Vector2 moveVec;
    float x;
    float y;
    [SerializeField]float speed = 15;
    public Rigidbody2D Rigidbody { get => rigidbody; set => rigidbody = value; }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Player;
        Rigidbody = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<VariableJoystick>();
    }
    protected override void UpdateWalk()
    {
        base.UpdateWalk();
        Rigidbody.MovePosition(Rigidbody.position + moveVec);

        // #. No input = No Rotation
        if (x < 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, -180, 0);
        }
    }
    protected override void UpdateIdle()
    {
        base.UpdateIdle();
    }
    // Update is called once per frame
    void Update()
    {
        x = joystick.Horizontal;
        y = joystick.Vertical;
        moveVec = new Vector2(x, y) * speed * Time.deltaTime;
        if (moveVec.sqrMagnitude != 0)
        {
            State = Define.State.Walk;
        }
        if (moveVec.sqrMagnitude == 0)
        {
            State = Define.State.Idle;
        }
        switch (State)
        {
            case Define.State.Idle:
                UpdateIdle();
                break;
            case Define.State.Walk:
                UpdateWalk();
                break;
        }
    }
}
