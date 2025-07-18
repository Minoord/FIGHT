using System;
using Ability.Weapons.Bullets;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace Ability.Weapons
{
    public class Gun : Weapon
    {
        private bool _isFiring;
        private Transform _transform;

        public void Init(Transform transform, int newDamage, int newAttackSpeed)
        {
            _transform = transform;
            SetValues(newDamage, newAttackSpeed);
        }
        
        public override void Use()
        {
            if (_isFiring)
            {
                return;
            }
            
            Attack();
        }

        public void SetValues(int? newDamage = null, int? newAttackSpeed = null)
        {
            if (newDamage.HasValue)
            {
                Damage = newDamage.Value;
            }

            if (newAttackSpeed.HasValue)
            {
                AttackSpeed = newAttackSpeed.Value;
            }

        }
        
        protected override void Attack()
        {
            _isFiring = true;
            if(!BulletManager.Instance.TrySpawn(Damage, _transform))
            {
                _isFiring = false;
                return;
            }

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
