using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;



public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Transform> TransformSpawn = new List<Transform>();
    [SerializeField] private Wave wave;
    public static List<GameUnit> EnemyOnGround = new List<GameUnit>();
    private int OptionEnemy;
    private bool DoneWave = false;

    private enum Wave
    {
        Easy = 0,
        Normal = 1,
        Difficult = 2,
        Hard = 3,
    }

    private void Update()
    {
        if(EnemyOnGround.Count == 0 && !DoneWave)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        for(int i = 1; i <= (int)wave + 1; i++)
        {
            for(int j = 0; j < TransformSpawn.Count; j++)
            {
                OptionEnemy = Random.Range(0, 101);
                if(OptionEnemy >= 50)
                {
                    Range enemy = PoolManager.Spawn<Range>(PoolType.Enemy, TransformSpawn[j].position, Quaternion.identity);
                    EnemyOnGround.Add(enemy);
                }
                else
                {
                    Meele enemy = PoolManager.Spawn<Meele>(PoolType.Enemy, TransformSpawn[j].position, Quaternion.identity);
                    EnemyOnGround.Add(enemy);
                }
            }
        }
        if((int)wave < 3)
            wave = (Wave)((int)wave + 1);
        else if((int)wave == 3)
            DoneWave = true;
    }
}
