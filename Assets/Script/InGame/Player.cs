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

    #region 움직임 관련

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

    #region 카메라 관련

    void CameraSet()
    {

    }

    #endregion

    void Start()
    {
        
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
