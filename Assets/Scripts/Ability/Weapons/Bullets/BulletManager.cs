using PoolSystems;

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

        public void Spawn(int damage)
        {
            Spawn(out IPoolEntity entity);

            if (entity is Bullet bullet)
            {
                bullet.Damage = damage;
            }
        }
    }
}
