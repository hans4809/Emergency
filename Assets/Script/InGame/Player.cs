using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action PlayerActionFix;
    public Action PlayerAction;
    private float _speed;
    private Vector3 _direction;

    // ī�޶� ����
    float x;
    float y;

    #region ������ ����

    private void PlayerMove()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetPlayerSpeedAndDirection(float speed, Vector3 direction)
    {
        _speed = speed;
        _direction = direction;
    }

    public void MoveStart()
    {
        PlayerActionFix += PlayerMove;
    }

    public void MoveEnd()
    {
        PlayerActionFix -= PlayerMove;
    }

    #endregion

    #region ī�޶� ����

    void CameraSet()
    {
        x = transform.position.x;
        y = transform.position.y;
        if (transform.position.x <= -4.5f) x = -4.5f;
        if (transform.position.x >= 4.5f) x = 4.5f;
        if (transform.position.y <= 10) y = 10;
        if (transform.position.y >= 110) y = 110;

        Camera.main.transform.position = new Vector3(x, y, -10);
    }

    #endregion

    void Start()
    {
        PlayerAction += CameraSet;
    }

    void Update()
    {
        PlayerAction?.Invoke();
    }

    void FixedUpdate()
    {
        PlayerActionFix?.Invoke();
    }
}
