using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure
{
    public abstract class PoolController<T> :MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T _prefab;
        [SerializeField] protected Transform _parentTransform;

        protected List<T> _pool = new List<T>();

        public T Spawn()
        {
            if (_pool.Count > 0)
            {
                foreach (T element in _pool)
                {
                    if (!element.gameObject.activeSelf)
                    {
                        element.gameObject.SetActive(true);
                        return element;
                    }
                }
            }

            T newT = Instantiate(_prefab,_parentTransform);
            _pool.Add(newT);
            newT.gameObject.SetActive(true);
            return newT;
        }

        public void ClearAll()
        {
            foreach (var element in _pool)
            {
                element.gameObject.SetActive(false);
            }
        }
        
        public void Despawn(T obj)
        {
            _pool.Find(match: x => !(obj is null) && x == obj).gameObject.SetActive(false);
        }
    }
}