using System;
using UnityEngine;

namespace PoolSystems
{
    public abstract class PoolEntity : MonoBehaviour
    {
        public string ID {get; set;}
        
        public Action<string, PoolEntity> OnDespawn { get; set; }

        public virtual void SetActive(bool active) => gameObject.SetActive(active);

        public virtual void Reset()
        {
            transform.position = Vector3.zero;
            transform.rotation = new Quaternion();
        }
        
        protected void OnDiSpawned() => OnDespawn?.Invoke(ID, this);
    }
}
