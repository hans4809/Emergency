using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Action _enemyAction;
    public bool _isMoveLeft;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        MoveStart();
        Invoke("Delete", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _enemyAction?.Invoke();
    }

    void MoveStart()
    {
        _enemyAction += Move;
    }

    void Move()
    {
        if(_isMoveLeft)
        {
            gameObject.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;        }
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
