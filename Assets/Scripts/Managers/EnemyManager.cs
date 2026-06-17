using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    
    public int enemiesToSpawn = 4;

    public EnemyData[] enemyStorage;
    
    public List<Transform> enemySpawnPositions = new List<Transform>();
    public List<Enemy> currentEnemies = new List<Enemy>();
    
    private BattleManager _battleManager;

    private void Start()
    {
        enemyStorage = Resources.LoadAll<EnemyData>("Enemies");
    }

    private void Awake()
    {
        if (_battleManager == null)
        {
            _battleManager = FindFirstObjectByType<BattleManager>();
        }
    }

    private void BattleSetup()
    {
        SpawnEncounter();
    }

    private void SpawnEncounter()
    {
        for (var i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy(enemyStorage[i], enemySpawnPositions[i]);
        }
    }

    private void SpawnEnemy(EnemyData enemyData, Transform spawnPositions)
    {
        var enemyObject = Instantiate(enemyPrefab,  spawnPositions.position, spawnPositions.rotation);
        var enemy = enemyObject.GetComponent<Enemy>();
        enemy.enemyData = enemyData;
        currentEnemies.Add(enemy);
    }
}
