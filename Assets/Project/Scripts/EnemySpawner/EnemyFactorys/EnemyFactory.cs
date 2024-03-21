using System;
using Enemies;
using Path.Core;
using UnityEngine;

namespace EnemySpawner.EnemyFactorys
{
    public abstract class EnemyFactory<T> : ScriptableObject where T : Enemy
    {
        public abstract T CreateReloctable(PathNode startNode);
    }
}
