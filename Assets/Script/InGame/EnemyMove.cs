using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Action enemyAction;

    // Start is called before the first frame update
    void Start()
    {
        MoveStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        enemyAction?.Invoke();
    }

    void MoveStart()
    {
        enemyAction += Move;
    }

    void Move()
    {
        gameObject.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
    }
}
