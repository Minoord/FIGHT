using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace WaveSpawnSystem
{
    [CreateAssetMenu(fileName = "EnemySpawnList", menuName = "Scriptable Objects/EnemySpawnList")]
    public class EnemySpawnList : ScriptableObject
    {
        public List<string> EasySpawns = new();
        public List<string> MediumSpawns = new();
        public List<string> _hardSpawns = new();
    }
}
