using HealthSystem;
using PoolSystems;
using UnityEngine;

namespace Useables.Weapons.Bullets
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : PoolEntity
    {
        [SerializeField] private float _health;
        [SerializeField] private float _speed;

        private float _lifeTimer;
        private Vector2 _direction;

        private readonly HealthManager _healthManager = new();
        
        public int Damage { private get; set; }

        private void OnEnable()
        {
            _healthManager.SetHealth(_health);
            _healthManager.OnDied += OnDeSpawned;
            _lifeTimer = 10;
            
        }

        private void Update()
        {
            Vector3 direction = transform.up * _speed * Time.deltaTime;
            transform.position += direction;
            
            if (_lifeTimer > 0)
            {
                _lifeTimer -= Time.deltaTime;
                return;
            }
            
            _healthManager.TakeDamage(_health);
        }

        private void OnDisable()
        {
            _healthManager.OnDied -= OnDeSpawned;
        }
        
        public override void SetActive(bool active) => gameObject.SetActive(active);
        
        public override void Reset()
        {
            transform.position = Vector3.zero;
            transform.rotation = new Quaternion();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CheckForEnemy(other.gameObject);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            CheckForEnemy(other.gameObject);
        }

        private void CheckForEnemy(GameObject gameObject)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                if (!WaveSpawner.Instance.ActivePrefabs.ContainsKey(gameObject.transform) ||  WaveSpawner.Instance.ActivePrefabs[gameObject.transform] is not Entity entity)
                {
                    Destroy(gameObject);
                    return;
                }
                
                entity.Damage(Damage);
                _healthManager.TakeDamage(_health);
            }
        }
    }
}
