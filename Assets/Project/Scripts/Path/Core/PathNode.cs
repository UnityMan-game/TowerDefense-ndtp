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
        
        protected abstract float size { get; }

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
            Debug.Log(_relocatables.Count);
        }

        public void Pass(Relocatable relocatable,float spacing)
        {
            int indexRelocatable = IndexRelocatable(relocatable);
            if(indexRelocatable == -2) return;
            if (indexRelocatable == _relocatables.Count - 1)
            {
                _relocatables[indexRelocatable].pathLevel += spacing;
                relocatable.Move();
                MoveRelocatable(relocatable);
                if (relocatable.pathLevel > size)
                {
                    _relocatables[indexRelocatable].Next().AddRelocatable(relocatable);
                    _relocatables.RemoveAt(indexRelocatable);
                    if (relocatable.pathLevel > size)
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
            if (indexRelocatable < _relocatables.Count - 1)
            {
                float frontRelocatableDistance =
                    (_relocatables[indexRelocatable + 1].pathLevel - _relocatables[indexRelocatable + 1].size / 2) -
                    (relocatable.pathLevel+relocatable.size/ 2);
                if (frontRelocatableDistance > spacing)
                {
                    relocatable.pathLevel += spacing;
                    relocatable.Move();
                    MoveRelocatable(relocatable);
                }
                if (relocatable.pathLevel > size)
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
        }

        protected abstract void MoveRelocatable(Relocatable relocatable);

        private int IndexRelocatable(Relocatable relocatable)
        {
            for (int i = 0; i < _relocatables.Count; i++)
            {
                if (_relocatables[i] == relocatable) return i;
            }

            return -2;
        }
    }
}
