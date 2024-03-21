using Path.Core;

namespace Path.PathNodes
{
    public class TowerPathNode : PathNode
    {
        protected override float _size { get; } = 5;
        protected override void MoveRelocatable(Relocatable relocatable)
        {
            relocatable.pathLevel = 0;
        }
    }
}
