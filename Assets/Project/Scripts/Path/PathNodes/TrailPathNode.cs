using Path.Core;
using UnityEngine;

namespace Path.PathNodes
{
    public class TrailPathNode : PathNode
    {
        [SerializeField] private Transform end;
        [SerializeField] private Transform start;
        [SerializeField] private int m;

        private void Awake()
        {
            maxNumberEnemies = m;
        }

        protected override float size { get; } = 2;
        protected override void MoveRelocatable(Relocatable relocatable)
        {
            Vector3 startPosition = start.position;
            Vector3 endPosition = end.position;
            relocatable.transform.position = startPosition + ((endPosition - startPosition).normalized *
                                                              (relocatable.pathLevel * Vector3.Distance(endPosition,startPosition))/2);
        }
    
    }
}