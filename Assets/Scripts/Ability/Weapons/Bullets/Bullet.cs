using System;
using HealthSystem;
using UnityEngine;

namespace Ability.Weapons.Bullets
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : MonoBehaviour, IPoolEntity
    {
        [SerializeField] private float _health;
        [SerializeField] private float _speed;
        
        private Vector2 _direction;

        private readonly HealthManager _healthManager = new();
        
        public int Damage { private get; set; }

        private void OnEnable()
        {
            _healthManager.SetHealth(_health);
            _healthManager.OnDied += OnDied;
            
        }

        private void Update()
        {
            Vector3 direction = transform.up * _speed * Time.deltaTime;
            transform.position += direction;
        }

        private void OnDisable()
        {
            _healthManager.OnDied -= OnDied;
        }
        
        public Action<IPoolEntity> OnDespawn { get; set; }
        
        public void SetActive(bool active) => gameObject.SetActive(active);
        
        public void Reset()
        {
            transform.position = Vector3.zero;
            transform.rotation = new Quaternion();
        }

        private void OnDied() => OnDespawn?.Invoke(this);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                //Get Entity from manager
                _healthManager.TakeDamage(_health);
            }
        }
    }
}
