using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Player : MonoBehaviour
{
    public Action PlayerActionFix;
    public Action PlayerAction;
    private float _speed;
    private Vector3 _direction;
    SpriteRenderer _renderer;
    Animator _animator;
    UI_Clear UI_Clear;

    // ī�޶� ����
    float x;
    float y;

    #region ������ ����

    private void PlayerMove()
    {
        if(_direction == Vector3.zero)
        {
            _animator.SetBool("Stop", true);
        }    
        else if(_direction.x <= 0)
        {
            _renderer.flipX = false;
        }
        else
        {
            _renderer.flipX = true;
        }
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetPlayerSpeedAndDirection(float speed, Vector3 direction)
    {
        _speed = speed;
        _direction = direction;
    }

    public void MoveStart()
    {
        _animator.SetBool("Stop", false);
        PlayerActionFix += PlayerMove;
    }

    public void MoveEnd()
    {
        _animator.SetBool("Stop", true);
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
        if (transform.position.y >= 230) y = 230;

        Camera.main.transform.position = new Vector3(x, y, -10);
    }

    void SortPlayer()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)((240 - transform.position.y) * 4);
    }

    #endregion

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        PlayerAction += CameraSet;
        PlayerAction += SortPlayer;
    }

    void Update()
    {
        PlayerAction?.Invoke();
    }

    void FixedUpdate()
    {
        PlayerActionFix?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Clear")
        {
            if(UI_Clear == null)
            {
                Managers.Sound.Stop(Managers.Sound._audioSources[(int)Define.Sound.BGM]);
                Managers.Sound.Play("Sounds/SFX/GameClear");
                UI_Clear = Managers.UI.ShowPopUpUI<UI_Clear>();
            }
        }
    }
}
