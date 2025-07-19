using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace WaveSpawnSystem
{
    [CreateAssetMenu(fileName = "EffectList", menuName = "Scriptable Objects/EffectList")]
    public class EffectList : ScriptableObject
    {
        public List<string> BuffsNames = new();
        public List<string> DebuffsNames = new();
    }
}
