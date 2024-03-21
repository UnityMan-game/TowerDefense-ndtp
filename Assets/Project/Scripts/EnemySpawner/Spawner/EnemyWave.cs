using System;
using Enemies;
using EnemySpawner.EnemyFactorys;

namespace EnemySpawner.Spawner
{
    [Serializable]
    public class EnemyWave
    {
        public float time;
        public float spawnTime;
        public int enemyCount;
        public EnemyFactory<Sceleton> enemyFactory; 
        
    }
}