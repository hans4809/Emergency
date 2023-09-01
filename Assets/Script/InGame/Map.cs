using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    GameObject _fixEnemy;
    [SerializeField]
    GameObject _moveLeftEnemy;
    [SerializeField]
    GameObject _moveRightEnemy;
    [SerializeField]
    GameObject _randomMoveEnemy;

    [SerializeField]
    List<Sprite> _enemySpriteList;

    [SerializeField]
    List<GameObject> _enemyList;

    GameObject player;

    List<int> _enemyPool;

    int _fixEnemyNum;
    int _moveEnemyNum;
    int _randomMoveEnemyNum;

    List<Vector3> enemyLoactionList = new List<Vector3>();

    float _yInterval;

    void Start()
    {
        DataManager.Single.Data.InGameData.Level = 3;

        player = GameObject.Find("Player");
        if (DataManager.Single.Data.InGameData.Level == 1)
        {
            _fixEnemyNum = 80;
        }
        else if (DataManager.Single.Data.InGameData.Level == 2)
        {
            _fixEnemyNum = 120;
        }
        else
        {
            _fixEnemyNum = 160;
        }
        if (DataManager.Single.Data.InGameData.Level == 1)
        {
            _yInterval = 10;
        }
        else if (DataManager.Single.Data.InGameData.Level == 2)
        {
            _yInterval = 8;
        }
        else
        {
            _yInterval = 6f;
        }
        MapMake();
        action += PlayerYCheck;
    }

    Action action;

    private void Update()
    {
        action?.Invoke();
    }

    int cnt = 1;

    void PlayerYCheck()
    {
        if (player.transform.position.y > _yInterval * cnt)
        {
            int num = UnityEngine.Random.Range(0, 7);
            if(num == 0)
            {
                MoveEnemySpawnLeft();
                MoveEnemySpawnRight();
            }
            else if (num <= 3)
            {
                MoveEnemySpawnLeft();
            }
            else
            {
                MoveEnemySpawnRight();
            }
            cnt++;
        }
    }

    void MapMake()
    {
        RandomSetting(_fixEnemy, new Vector3(0, 14, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 34, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 54, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 74, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 94, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 114, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 134, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 154, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 174, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 194, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 214, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(_fixEnemy, new Vector3(0, 222, 0), 18, 16, _fixEnemyNum / 12);
        EnemySort();
    }

    void MoveEnemySpawnLeft()
    {
        int num1 = 0;
        int num2 = 0;
        if (DataManager.Single.Data.InGameData.Level == 1)
        {
            num1 = 2;
            num2 = 6;
        }
        else if (DataManager.Single.Data.InGameData.Level == 2)
        {
            num1 = 4;
            num2 = 12;
        }
        else
        {
            num1 = 6;
            num2 = 18;
        }
        RandomSetting(_moveLeftEnemy, new Vector3(17, 18, 0) + GameObject.Find("Player").transform.position, 16, 4, UnityEngine.Random.Range(num1, num2+1));
    }

    void MoveEnemySpawnRight()
    {
        RandomSetting(_moveRightEnemy, new Vector3(-17, 18, 0) + GameObject.Find("Player").transform.position, 16, 4, UnityEngine.Random.Range(1, 4));
    }

    void RandomSetting(GameObject enemy, Vector3 defaultV3, int width, int height, int num) // 중심점 가로 세로 인원수
    {
        for(int i = 0; i < num; i++)
        {
            float x;
            float y;
            x = UnityEngine.Random.Range(-width * 0.5f, width * 0.5f);
            y = UnityEngine.Random.Range(-height * 0.5f, height * 0.5f);

            foreach(Vector3 v in enemyLoactionList)
            {
                while((Mathf.Abs(v.y - y) < 1.5f) && (Mathf.Abs(v.x - x) < 2.5f))
                {
                    x = UnityEngine.Random.Range(-width * 0.5f, width * 0.5f);
                    y = UnityEngine.Random.Range(-height * 0.5f, height * 0.5f);
                }
            }

            enemyLoactionList.Add(new Vector3(x, y, 0));

            GameObject enemyObj = Instantiate(enemy, new Vector3(defaultV3.x + x, defaultV3.y + y, 0), Quaternion.identity);
            int num2 = UnityEngine.Random.Range(0, 101);
            if (num2 > 80)
            {
                num2 = 2;
            }
            else if (num2 > 40)
            {
                num2 = 1;
            }
            else
                num2 = 0;
            enemyObj.GetComponent<SpriteRenderer>().sprite = _enemySpriteList[num2];
            if(enemy == _fixEnemy)
            {
                enemyObj.GetComponent<SpriteRenderer>().flipX = (UnityEngine.Random.Range(0, 2) == 0);
            }
            if(enemy == _moveLeftEnemy || enemy == _moveRightEnemy)
            {
                if(num2 == 0)
                {
                    enemyObj.GetComponent<Animator>().SetBool("Enemy1", true);
                    enemyObj.GetComponent<EnemyMove>().speed = 5;
                }
                else if(num2 == 1)
                {
                    enemyObj.GetComponent<Animator>().SetBool("Enemy2", true);
                    enemyObj.GetComponent<EnemyMove>().speed = 4;
                }
                else
                {
                    enemyObj.GetComponent<Animator>().SetBool("Enemy3", true);
                    enemyObj.GetComponent<EnemyMove>().speed = 3f;
                }
            }
            enemyObj.GetComponent<SpriteRenderer>().sortingOrder = (int)((240 - enemyObj.transform.position.y) * 4);
            _enemyList.Add(enemyObj);
        }
    }

    void EnemySort()
    {
        _enemyList.Sort(SortByY);

        int cnt = _enemyList.Count + 1;

        foreach(GameObject enemy in _enemyList)
        {
            enemy.GetComponent<SpriteRenderer>().sortingOrder = (int)((240 - enemy.transform.position.y) * 4);
            cnt--;
        }
    }

    int SortByY(GameObject A, GameObject B)
    {
        return A.transform.position.y <= B.transform.position.y ? -1 : 1;
    }
}