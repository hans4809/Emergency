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
    UI_InGame UI_InGame;

    GameObject _leftDoor;
    GameObject _rightDoor;
    GameObject _panel;

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
        _leftDoor = GameObject.Find("LeftDoor");
        _rightDoor = GameObject.Find("RightDoor");
        _panel = GameObject.Find("UI_Joystick").transform.GetChild(1).gameObject;
        PlayerAction += CameraSet;
        PlayerAction += SortPlayer;
        UI_InGame = FindObjectOfType<UI_InGame>();
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
                DataManager.Single.Data.InGameData.IsClear = true;
                _panel.SetActive(true);

                StartCoroutine(playerMove());
                switch (DataManager.Single.Data.InGameData.Level)
                {
                    case 1:
                        DataManager.Single.Data.InGameData.Score1 = UI_InGame.currentTime;
                        break;
                    case 2:
                        DataManager.Single.Data.InGameData.Score2 = UI_InGame.currentTime;
                        break;
                    case 3:
                        DataManager.Single.Data.InGameData.Score3 = UI_InGame.currentTime;
                        break;
                }
                DataManager.Single.Save();
                Managers.Sound.Stop(Managers.Sound._audioSources[(int)Define.Sound.BGM]);
                Managers.Sound.Play("Sounds/BGM/GameClear", Define.Sound.BGM);
            }
        }
    }

    IEnumerator playerMove()
    { // -5.59 -1.83 -3.76
        _animator.SetBool("Clear", true);
        yield return new WaitForSeconds(1f);

        _animator.SetBool("Clear", false);

        for (int i = 0; i < 200; i++)
        {
            _animator.SetBool("Stop", false);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 232.2f, 0), 0.05f);
            yield return new WaitForSeconds(0.01f);
        }

        _animator.SetBool("Clear", true);

        yield return new WaitForSeconds(0f);
        for(int i = 0; i < 100; i++)
        {
            _rightDoor.transform.position += new Vector3(-0.0376f, 0, 0);
            _leftDoor.transform.position += new Vector3(0.0376f, 0, 0);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(1f);

        UI_Clear = Managers.UI.ShowPopUpUI<UI_Clear>();
    }
}