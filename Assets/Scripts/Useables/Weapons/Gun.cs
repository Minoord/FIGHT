using System;
using AbilitySystem;
using UnityEngine;
using Useables.Weapons.Bullets;
using Task = System.Threading.Tasks.Task;

namespace Useables.Weapons
{
    public class Gun : Weapon
    {
        private bool _isFiring;
        private Transform _transform;

        public void Init(Transform transform, int newDamage, float newAttackSpeed)
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

        public void SetValues(int? newDamage = null, float? newAttackSpeed = null)
        {
            if (newDamage.HasValue)
            {
                Damage = newDamage.Value;
            }

            if (newAttackSpeed.HasValue)
            {
                float attackSpeed = newAttackSpeed.Value * 1000;
                AttackSpeed = (int) attackSpeed;
            }

        }
        
        protected override void Attack()
        {
            _isFiring = true;
            if(!BulletManager.Instance.TrySpawn(Damage + AbilityManager.Instance.GetStrengthModifier(), _transform))
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
                await Task.Delay(AttackSpeed * AbilityManager.Instance.GetAttackSpeedModifier());

                _isFiring = false;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
