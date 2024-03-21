using Path.Core;
using Path.PathNodes;
using UnityEngine;

namespace Enemies
{
    public class TestEnemy : Enemy
    {
        public TestEnemy(PathNode startNode) : base(startNode)
        {
            
        }
        
        [SerializeField] private PathNode start;

        [SerializeField] private float speed;

        [SerializeField] private KeyCode keyCode;

        public override PathNode Next()
        {
            return Next(currentPathNode);
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
        
        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                start.AddRelocatable(this);
            }

            if (currentPathNode)
            {
                currentPathNode.Pass(this,Time.deltaTime * speed);
            }
        }
    }
}