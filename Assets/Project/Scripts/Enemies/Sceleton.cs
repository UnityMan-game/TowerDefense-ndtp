using System;
using Path.Core;
using Path.PathNodes;
using UnityEngine;

namespace Enemies
{
    public class Sceleton : Enemy
    {
        public Sceleton(PathNode startNode,int health = 100) : base(startNode)
        {
            this.health = health;
        }
        public override PathNode Next()
        {
            return Next(currentPathNode);
        }

        private void Update()
        {
            currentPathNode.Pass(this,Time.deltaTime);
        }

        private PathNode Next(PathNode pathNode)
        {
            foreach (PathNode nextPathNode in pathNode.next)
            {
                if (!nextPathNode) continue;
                if (nextPathNode.GetType() == typeof(TowerPathNode)) return nextPathNode;
                if (Next(nextPathNode)) return nextPathNode;
            }

            return null;
        }
    }
}
