using System.Collections.Generic;
using UnityEngine;

namespace Path.Core
{
    public abstract class PathNode : MonoBehaviour
    {
        private readonly List<Relocatable> _waitingRelocatables = new List<Relocatable>();
        private readonly List<Relocatable> _relocatables = new List<Relocatable>();
        
        protected int maxNumberEnemies;

        public PathNode[] next;
        
        protected abstract float _size { get; }

        public void AddRelocatable(Relocatable relocatable)
        {
            relocatable.currentPathNode = this;
            relocatable.pathLevel = 0;
            if (_relocatables.Count >= maxNumberEnemies)
            {
                _waitingRelocatables.Add(relocatable);
                return;
            }
            _relocatables.Insert(0,relocatable);
        }

        public void RemoveRelocatable(Relocatable relocatable)
        {
            if(!_relocatables.Contains(relocatable)) return;
            _relocatables.Remove(relocatable);
        }

        public void Pass(Relocatable relocatable,float spacing)
        {
            if (!_relocatables.Contains(relocatable)) return;
            int indexRelocatable = _relocatables.IndexOf(relocatable);

            //eсли враг первый на пути
            if (indexRelocatable == _relocatables.Count - 1)
            {
                _relocatables[indexRelocatable].pathLevel += spacing;
                relocatable.Move();
                MoveRelocatable(relocatable);
                //если враг дошел до конца
                if (relocatable.pathLevel > _size)
                {
                    _relocatables[indexRelocatable].Next().AddRelocatable(relocatable);
                    _relocatables.RemoveAt(indexRelocatable);
                    if (relocatable.pathLevel > _size)
                    {
                        _relocatables[indexRelocatable].Next().AddRelocatable(relocatable);
                        _relocatables.RemoveAt(indexRelocatable);
                        if (_waitingRelocatables[0])
                        {
                            _relocatables.Insert(0,_waitingRelocatables[0]);
                            _waitingRelocatables.RemoveAt(0);
                        
                        }
                    }
                }
                return;
            }
            
            //eсли враг не первый на пути
            if (indexRelocatable < _relocatables.Count - 1)
            {
                float frontRelocatableDistance =
                    (_relocatables[indexRelocatable + 1].pathLevel - _relocatables[indexRelocatable + 1].size / 2) - 
                    (relocatable.pathLevel+relocatable.size/ 2);
                
                //если враг впереди не препядствует передвижению
                if (frontRelocatableDistance > spacing)
                {
                    relocatable.pathLevel += spacing;
                    relocatable.Move();
                    MoveRelocatable(relocatable);
                }
            }
        }

        protected abstract void MoveRelocatable(Relocatable relocatable);
    }
}
