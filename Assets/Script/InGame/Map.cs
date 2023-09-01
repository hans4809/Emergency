using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    GameObject _enemy;

    [SerializeField]
    List<Sprite> _enemySpriteList;

    [SerializeField]
    List<GameObject> _enemyList;

    List<int> _enemyPool;

    int _fixEnemyNum;
    int _moveEnemyNum;
    int _randomMoveEnemyNum;

    List<Vector3> enemyLoactionList = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        _fixEnemyNum = 120;
        MapMake();
    }

    void MapMake()
    {
        RandomSetting(new Vector3(0, 14, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 34, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 54, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 74, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 94, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 114, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 134, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 154, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 174, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 194, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 214, 0), 18, 20, _fixEnemyNum / 12);
        RandomSetting(new Vector3(0, 222, 0), 18, 16, _fixEnemyNum / 12);
        EnemySort();
    }

    void RandomSetting(Vector3 defaultV3, int width, int height, int num) // 중심점 가로 세로 인원수
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
                    Debug.Log("너무 가까워!");
                }
            }

            enemyLoactionList.Add(new Vector3(x, y, 0));

            GameObject enemyObj = Instantiate(_enemy, new Vector3(defaultV3.x + x, defaultV3.y + y, 0), Quaternion.identity);
            enemyObj.GetComponent<SpriteRenderer>().sprite = _enemySpriteList[UnityEngine.Random.Range(0, 3)];
            enemyObj.GetComponent<SpriteRenderer>().flipX = (UnityEngine.Random.Range(0, 2) == 0);
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