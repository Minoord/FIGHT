namespace AbilitySystem
{
    public class AbilityManager
    {
        public static AbilityManager Instance => _instance ??= new AbilityManager();
        
        public bool IsAbilityEnabled { private get; set; }
        
        private static AbilityManager _instance;
        
        public int Shields { get; set; }
        public int StrengthModifier { get; set; }
        public int AttackSpeedModifier { internal get; set; } = 1;

        public int GetShields()
        {
            if (!IsAbilityEnabled)
            {
                return 0;
            }
            
            int shields = Shields;
            Shields--;

            return shields;
        }

        public int GetStrengthModifier()
        {
            return IsAbilityEnabled ? StrengthModifier : 0;
        }

        public int GetAttackSpeedModifier()
        {
            if (!IsAbilityEnabled)
            {
                AttackSpeedModifier = 1;
            }
            
            return AttackSpeedModifier;
        }
    }
}
