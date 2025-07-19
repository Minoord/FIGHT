using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace PoolSystems
{
    public abstract class PoolSystem<TSystem, TEntity> : MonoBehaviour 
        where TSystem : PoolSystem<TSystem, TEntity>
        where TEntity : PoolEntity
    {
        [SerializeField] private List<PrefabInstances> _prefabReference;
        
        private bool _isInstantiated;
        private Dictionary<string, GameObject> _prefabs = new();
        private Dictionary<string, List<TEntity>> _deActivePrefabs = new();
        
        public Dictionary<Transform, TEntity> ActivePrefabs = new();
        
        public static TSystem Instance { get; private set; }
        
        private async void Awake()
        {
            SetInstance();

            foreach (PrefabInstances prefabReference in _prefabReference)
            {
                GameObject prefab = await Addressables.LoadAssetAsync<GameObject>(prefabReference.prefabReference).Task;

                _prefabs.TryAdd(prefabReference.id, prefab);
            }
            

            if (_prefabs.Count > 0)
            {
                _isInstantiated = true;
                return;
            }
            
            Debug.LogError($"Cannot load bullet asset: {_prefabReference}. Destroying bulletManager");
            Destroy(this);
        }

        protected virtual void SetInstance()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = (TSystem)this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public bool TrySpawn(string id, out TEntity newEntity)
        {
            newEntity = default;

            if (!_isInstantiated)
            {
                return false;
            }

            if (_deActivePrefabs.ContainsKey(id) && _deActivePrefabs[id].Count > 0)
            {
                newEntity = _deActivePrefabs[id][0];
                newEntity.Reset();
                newEntity.SetActive(true);
                
                _deActivePrefabs[id].RemoveAt(0);
                ActivePrefabs.Add(newEntity.transform, newEntity);
                
            }
            else
            {
                if (!_prefabs.TryGetValue(id, out GameObject prefab))
                {
                   return false;  
                }
                
                if (!Instantiate(prefab, transform).TryGetComponent(out newEntity))
                {
                    Debug.LogError($"Cannot spawn asset: {_prefabReference}. Couldn't find Correct IPoolEntity");
                    return false;
                }
                
                ActivePrefabs.Add(newEntity.transform, newEntity);
            }

            newEntity.ID = id;
            newEntity.OnDespawn += Despawn;
            return true;
        }

        private void Despawn(string id, PoolEntity poolEntity)
        {
            poolEntity.OnDespawn -= Despawn;
            poolEntity.SetActive(false);
            TEntity entity = (TEntity) poolEntity;
            
            ActivePrefabs.Remove(entity.transform, out entity);
            
            if (!_deActivePrefabs.ContainsKey(id))
            {
                _deActivePrefabs.Add(id, new List<TEntity>());
            }
                
            _deActivePrefabs[id].Add(entity);
        }

        [Serializable]
        private struct PrefabInstances
        {
            public string id;
            public AssetReference prefabReference;
        }
    }
}
