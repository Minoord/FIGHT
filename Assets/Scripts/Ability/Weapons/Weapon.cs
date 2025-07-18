using UnityEngine;

namespace Ability.Weapons
{
    public abstract class Weapon : IAbility
    {
        protected int Damage; 
        protected int AttackSpeed;
        
        public virtual void Use()
        {
           Attack();
        }

        protected abstract void Attack();
    }
}