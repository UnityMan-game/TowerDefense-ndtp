using System.Threading.Tasks;
using Enemies;
using Path.Core;
using UnityEngine;

namespace EnemySpawner.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private PathNode startPathNode;

        [SerializeField] private EnemyWave[] enemyWaves;
        
        private async void Start()
        {
            foreach (var enemy in enemyWaves)
            {
                await Task.Delay((int) (enemy.time * 1000));
                for (int j = 0; j < enemy.enemyCount; j++)
                {
                    startPathNode.AddRelocatable(Instantiate(enemy.enemyFactory.CreateReloctable(startPathNode)).GetComponent<Enemy>());
                    await Task.Delay((int) (enemy.spawnTime * 1000));
                }
            }
        }
    }
}
