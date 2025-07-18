using PoolSystems;
using UnityEngine;

namespace Ability.Weapons.Bullets
{
    public class BulletManager : PoolSystem
    {
        public static BulletManager Instance { get; private set; }

        protected override void SetInstance()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public bool TrySpawn(int damage, Transform transform)
        {
            if (!TrySpawn(out IPoolEntity entity))
            {
                return false;  
            }

            if (entity is Bullet bullet)
            {
                bullet.Damage = damage;
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
            }
            
            return true;
        }
    }
}
