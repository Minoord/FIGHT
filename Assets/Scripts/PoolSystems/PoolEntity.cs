using System;
using UnityEngine;

namespace PoolSystems
{
    public abstract class PoolEntity : MonoBehaviour
    {
        public string ID {get; set;}
        
        public Action<string, PoolEntity> OnDespawn { get; set; }

        public virtual void SetActive(bool active) => gameObject.SetActive(active);

        public virtual void Reset(Transform spawnPlace)
        {
            transform.position = spawnPlace.position;
            transform.rotation = spawnPlace.rotation;
        }
        
        protected virtual void OnDeSpawned() => OnDespawn?.Invoke(ID, this);
    }
}
