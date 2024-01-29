using UnityEngine;

namespace Path.Core
{
    public abstract class Relocatable : MonoBehaviour
    {
        public float pathLevel;
        public float size;
        public PathNode currentPathNode;
        
        public abstract PathNode Next();

        public abstract void Move();
    }
}
