using System;
using Ability.Weapons.Bullets;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace Ability.Weapons
{
    public class Gun : Weapon
    {
        private bool _isFiring;
        
        public override void Use()
        {
            if (_isFiring)
            {
                return;
            }
            
            Attack();
        }
        
        protected override void Attack()
        {
            _isFiring = true;
            BulletManager.Instance.Spawn(Damage);

            DrawbackTimer();
        }

        private async void DrawbackTimer()
        {
            try
            {
                await Task.Delay(AttackSpeed * 1000);

                _isFiring = false;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
