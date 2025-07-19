using System;
using HealthSystem;
using PoolSystems;
using UnityEngine;

namespace Ability.Weapons.Bullets
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : PoolEntity
    {
        [SerializeField] private float _health;
        [SerializeField] private float _speed;
        
        private Vector2 _direction;

        private readonly HealthManager _healthManager = new();
        
        public int Damage { private get; set; }

        private void OnEnable()
        {
            _healthManager.SetHealth(_health);
            _healthManager.OnDied += OnDiSpawned;
            
        }

        private void Update()
        {
            Vector3 direction = transform.up * _speed * Time.deltaTime;
            transform.position += direction;
        }

        private void OnDisable()
        {
            _healthManager.OnDied -= OnDiSpawned;
        }
        
        public override void SetActive(bool active) => gameObject.SetActive(active);
        
        public override void Reset()
        {
            transform.position = Vector3.zero;
            transform.rotation = new Quaternion();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (!WaveSpawner.Instance.ActivePrefabs.ContainsKey(other.transform) ||  WaveSpawner.Instance.ActivePrefabs[other.transform] is not Entity entity)
                {
                    Destroy(other.gameObject);
                    return;
                }
                
                entity.Damage(Damage);
               _healthManager.TakeDamage(_health);
            }
        }
    }
}
