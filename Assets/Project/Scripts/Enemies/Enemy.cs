using Demagamle;
using Path.Core;

namespace Enemies
{
    public abstract class Enemy : Relocatable,IDemagable
    {
        public Enemy(PathNode startNode) : base(startNode)
        {
            
        }
        public int health { get; protected set; }
        public void Damage(int damage)
        {
            OnDamage();
            
            health -= damage;
            
            if (health <= 0)
            {
                Dead();
            }
        }

        private void Dead()
        {
            OnDead();
            
            currentPathNode.RemoveRelocatable(this);
            Destroy(gameObject);
        }
        
        protected virtual void OnDead(){}
        protected virtual void OnDamage(){}


    }
}