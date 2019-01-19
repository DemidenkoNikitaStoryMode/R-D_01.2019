using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public List<TypePrefabPair> EnemyPrefabs;
    public List<EnemyWave> Waves;
    public RadiusSpawner Spawner;

    private void Start()
    {
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        foreach (var wave in Waves)
        {
            yield return new WaitForSeconds(wave.Delay);
            foreach (var enemyAmountPair in wave.Enemies)
            {
                var prefab = GetPrefabByType(enemyAmountPair.Enemy);
                for (int i = 0; i < enemyAmountPair.Amount; i++)
                {
                    Spawner.Spawn(prefab);
                }
            }
        }
    }

    private GameObject GetPrefabByType(EnemyType type)
    {
        return EnemyPrefabs.First((enemyType) => enemyType.Type == type).Prefab;
    }

    [Serializable]
    public struct EnemyWave
    {
        // Delay since last wave
        public float Delay;
        // Amount of enemies of type
        public List<EnemyAmountPair> Enemies;

        [Serializable]
        public struct EnemyAmountPair
        {
            public EnemyType Enemy;
            public int Amount;
        }
    }

    [Serializable]
    public struct TypePrefabPair
    {
        public EnemyType Type;
        public GameObject Prefab;
    }
}
