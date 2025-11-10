using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;



public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Transform> TransformSpawn = new List<Transform>();
    [SerializeField] private Wave wave;
    [SerializeField] private Transform _tf;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameManager gameManager;
    public static List<GameUnit> EnemyOnGround = new List<GameUnit>();
    private int OptionEnemy;
    private bool DoneWave = false;


    public enum Wave
    {
        Easy = 0,
        Normal = 1,
        Difficult = 2,
        Hard = 3,
        Boss = 4,
    }

    private void Awake()
    {
        EnemyOnGround.Clear();
        // TODO : Fix cái lỏ này
    }

    private void Update()
    {
        if(EnemyOnGround.Count == 0 && !DoneWave)
        {
            SpawnEnemy();
        }
        //Debug.Log(EnemyOnGround.Count);
    }

    private void SpawnEnemy()
    {
        if((int)wave <= 3)
        for(int i = 1; i <= (int)wave + 1; i++)
        {
            for(int j = 0; j < TransformSpawn.Count; j++)
            {
                OptionEnemy = Random.Range(0, 101);
                if(OptionEnemy >= 50)
                {
                    Range enemy = PoolManager.Spawn<Range>(PoolType.EnemyRange, TransformSpawn[j].position, Quaternion.identity);
                    enemy.OnInit(_tf,playerManager, gameManager);
                    EnemyOnGround.Add(enemy);
                }
                else
                {
                    Meele enemy = PoolManager.Spawn<Meele>(PoolType.EnemyMeele, TransformSpawn[j].position, Quaternion.identity);
                    enemy.OnInit(_tf, playerManager, gameManager);
                    EnemyOnGround.Add(enemy);
                }
            }
        }
        if((int)wave <= 3)
            wave = (Wave)((int)wave + 1);
        if((int)wave == 4)
            DoneWave = true;
    }

    public bool checkWave()
    {
        return wave == Wave.Boss;
    }
}
