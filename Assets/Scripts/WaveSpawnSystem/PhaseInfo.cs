using UnityEngine;

namespace WaveSpawnSystem
{
    [CreateAssetMenu(fileName = "PhaseInfo", menuName = "Scriptable Objects/PhaseInfo")]
    public class PhaseInfo : ScriptableObject
    {
        public EnemySpawnList EnemySpawnList;
        public EffectList EffectList;
        public int AmountOfEnemiesToSpawn;
    }
}
