using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    List<int> enemyPool;

    int _fixEnemyNum;
    int _moveEnemyNum;
    int _randomMoveEnemyNum;

    // Start is called before the first frame update
    void Start()
    {
        _fixEnemyNum = 30;
        MapMake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MapMake()
    {
        RandomSetting(new Vector3(0, 60, 0), 18, 120, _fixEnemyNum);
    }

    void RandomSetting(Vector3 defaultV3, int width, int height, int num) // 중심점 가로 세로 인원수
    {
        List<Vector3> enemyLoactionList = new List<Vector3>();

        for(int i = 0; i < num; i++)
        {
            float x;
            float y;
            x = UnityEngine.Random.Range(-width * 0.5f, width * 0.5f);
            y = UnityEngine.Random.Range(-height * 0.5f, height * 0.5f);

            Instantiate(enemy, new Vector3(defaultV3.x + x, defaultV3.y + y, 0), Quaternion.identity);
        }
    }
}