using System;

namespace HealthSystem
{
    public class HealthManager
    {
        public Action OnDied;
        
        private float _health;

        public void SetHealth(float health)
        {
            _health = health;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                OnDied?.Invoke();
            }
        }
    }
}
