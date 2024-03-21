using Enemies;
using Path.Core;
using UnityEngine;

namespace EnemySpawner.EnemyFactorys
{

    [System.Serializable]
    [CreateAssetMenu(fileName = "SceletonFactory", menuName = "EnemyFectorys/SceletonFactory")]
    public class SceletonFactory : EnemyFactory<Sceleton>
    {
        [SerializeField] private int health;

        [SerializeField] private GameObject sceletonPrefab;

        public override Sceleton CreateReloctable(PathNode startNode)
        {
            return sceletonPrefab.GetComponent<Sceleton>();
        }
    }
}