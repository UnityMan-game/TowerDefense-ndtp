using Path.Core;

namespace Enemies
{
    public abstract class Enemy : Relocatable
    {
        public abstract override PathNode Next();
    }
}