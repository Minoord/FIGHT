using System;
using HealthSystem;
using UnityEngine;

namespace Ability.Weapons.Bullets
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : MonoBehaviour, IPoolEntity
    {
        [SerializeField] private float _health;

        private readonly HealthManager _healthManager = new();
        
        public int Damage { private get; set; }

        private void OnEnable()
        {
            _healthManager.SetHealth(_health);
            _healthManager.OnDied += OnDied;
        }

        private void OnDisable()
        {
            _healthManager.OnDied -= OnDied;
        }
        
        public Action<IPoolEntity> OnDespawn { get; set; }
        
        public void SetActive(bool active) => gameObject.SetActive(active);

        private void OnDied() => OnDespawn?.Invoke(this);

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                //Get Entity from manager
                _healthManager.TakeDamage(_health);
            }
        }
    }
}
