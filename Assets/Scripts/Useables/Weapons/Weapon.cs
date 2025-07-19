namespace Useables.Weapons
{
    public abstract class Weapon : IUseable
    {
        public int Damage { get; protected set; }
        public int AttackSpeed { get; protected set; }
        
        public virtual void Use()
        {
           Attack();
        }

        protected abstract void Attack();
    }
}