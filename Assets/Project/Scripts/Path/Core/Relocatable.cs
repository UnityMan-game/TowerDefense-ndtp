using UnityEngine;

namespace Path.Core
{
    public abstract class Relocatable : MonoBehaviour
    {
        public float pathLevel;
        public float size;
        public PathNode currentPathNode;

        public Relocatable(PathNode startNode)
        {
            startNode.AddRelocatable(this);
        }
        public abstract PathNode Next();

        public virtual void Move(){}
    }
}
