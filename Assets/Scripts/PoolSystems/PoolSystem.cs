using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace PoolSystems
{
    public abstract class PoolSystem : MonoBehaviour
    {
        [SerializeField] private AssetReference _prefabReference;
        
        private GameObject _prefab;
        private List<GameObject> _activePrefabs = new();
        private List<IPoolEntity> _deActivePrefabs = new();
        
        private async void Awake()
        {
            SetInstance();
            
            _prefab = await Addressables.LoadAssetAsync<GameObject>(_prefabReference).Task;

            if (_prefab)
            {
                return;
            }
            
            Debug.LogError($"Cannot load bullet asset: {_prefabReference}. Destroying bulletManager");
            Destroy(this);
        }

        protected abstract void SetInstance();

        public void Spawn(out IPoolEntity newEntity)
        {
            if (_deActivePrefabs.Count > 0)
            {
                newEntity = _deActivePrefabs[0];
                newEntity.SetActive(true);
                
                _deActivePrefabs.RemoveAt(0);
              
            }
            else
            {
                if (!Instantiate(_prefab, transform).TryGetComponent(out newEntity))
                {
                    Debug.LogError($"Cannot spawn bullet asset: {_prefabReference}. Couldn't find IPoolEntity");
                    return;
                }
            }

            newEntity.OnDespawn += Despawn;
        }

        private void Despawn(IPoolEntity poolEntity)
        {
            poolEntity.OnDespawn -= Despawn;
            poolEntity.SetActive(false);
            
            _deActivePrefabs.Add(poolEntity);
        }
    }
}
