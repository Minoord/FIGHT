namespace AbilitySystem
{
    public class AbilityManager
    {
        public static AbilityManager Instance => _instance ??= new AbilityManager();
        
        public bool IsAbilityEnabled { private get; set; }
        
        private static AbilityManager _instance;
        
        public int Shields { private get; set; }
        public int StrengthModifier { private get; set; }
        public int AttackSpeedModifier { private get; set; }

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
                AttackSpeedModifier = 0;
            }
            
            return AttackSpeedModifier;
        }
    }
}
