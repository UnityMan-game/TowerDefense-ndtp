using Path.Core;

namespace EnemySpawner.EnemyFactorys
{
    
    public interface IReloctableFectory<out T> where T : Relocatable
    {
        public T CreateReloctable(PathNode startNode);
    }
}