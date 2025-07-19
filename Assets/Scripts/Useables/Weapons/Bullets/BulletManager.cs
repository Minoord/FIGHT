using PoolSystems;
using UnityEngine;

namespace Useables.Weapons.Bullets
{
    public class BulletManager : PoolSystem<BulletManager, Bullet>
    {
        public bool TrySpawn(int damage, Transform transform)
        {
            if (!TrySpawn("Bullet", out Bullet bullet))
            {
                return false;  
            }
          
            bullet.Damage = damage;
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            
            return true;
        }
    }
}
