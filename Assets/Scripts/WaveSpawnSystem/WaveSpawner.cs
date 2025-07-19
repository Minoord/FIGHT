using System;
using System.Collections.Generic;
using PoolSystems;
using UnityEditor.Build;
using UnityEngine;
using WaveSpawnSystem;

public class WaveSpawner : PoolSystem<WaveSpawner, Entity>
{
   // Set Phase info 
   // Start phase
   // Calculate how many/which enemies per wave
   // Start wave
   //Spawn in entities
   // entities all died 
   // Stop wave
   // Start next wave
   // No more waves call onphase ended
   // Start next phase
   
   public Action PhaseEnded;

   [SerializeField] private float _spawnTime;
   
   private PhaseInfo _currentPhase;
   
   private int _currentWaveIndex;
   private List<WaveInfo> _waves = new();
   
   private float _spawnTimer;
   private int _enemiesSpawned;
   private int _buffSpawnChance = 50;
   private int _deBuffSpawnChance;
   private bool _isDoneSpawning;
   
   public void StartPhase(PhaseInfo phaseInfo)
   {
      _currentPhase = phaseInfo;

      //ToDo: Change to calculation
      int amountOfWaves = 1;
      int amountOfEasyEnemies = 2;
      int amountOfMediumEnemies = 0;
      int amountOfHardEnemies = 0;

      for (int i = 0; i < amountOfWaves; i++)
      {
         _waves.Add(new WaveInfo(amountOfEasyEnemies,amountOfMediumEnemies,amountOfHardEnemies));
      }
      
      StartWave();
   }

   private void Update()
   {
      if (_isDoneSpawning)
      {
         return;
      }

      if (_spawnTimer > 0)
      {
         _spawnTimer -= Time.deltaTime;
         return;
      }

      if (TrySpawn())
      {
         _enemiesSpawned++;
         _spawnTimer = _spawnTime;
         
         if (_enemiesSpawned == _waves[_currentWaveIndex].AmountOfEnemiesToSpawn)
         {
            EndWave();
         }
      }
   }

   private void StartWave()
   {
      _isDoneSpawning = false;
      _spawnTimer = _spawnTime;
   }

   private bool TrySpawn()
   {
      return TrySpawn(GetEntityName(), out Entity _);
   }

   private string GetEntityName()
   {
      int randomPercentage = UnityEngine.Random.Range(0, 100);
      if (randomPercentage <= _buffSpawnChance) return GetBuff();
      
      randomPercentage -= _buffSpawnChance;
      if (randomPercentage <= _deBuffSpawnChance) return GetDeBuff();

      return GetEnemy();
   }

   private string GetBuff()
   {
      int randomNumber = UnityEngine.Random.Range(0, _currentPhase.EffectList.BuffsNames.Count);
      return _currentPhase.EffectList.BuffsNames[randomNumber];
   }
   
   private string GetDeBuff()
   {
      int randomNumber = UnityEngine.Random.Range(0, _currentPhase.EffectList.DebuffsNames.Count);
      return _currentPhase.EffectList.BuffsNames[randomNumber];
   }

   private string GetEnemy()
   {
      return "Barb";
   }

   private void EndWave()
   {
      _isDoneSpawning = true;
      _currentWaveIndex++;

      if (_currentWaveIndex <= _waves.Count - 1)
      {
         StartWave();
      }
      else
      {
         PhaseEnded?.Invoke();
      }
   }
}
