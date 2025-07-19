
using System;
using HealthSystem;
using PlayerControllers;
using PoolSystems;
using UnityEngine;

public abstract class Entity : PoolEntity
{
    [SerializeField] protected float MovementSpeed = 1f;
    [SerializeField] protected float Health = 1f;
    [SerializeField] protected int Strength = 1;
    
    protected readonly HealthManager HealthManager = new();

    protected virtual void OnEnable()
    {
        HealthManager.SetHealth(Health);
        HealthManager.OnDied += OnDeSpawned;
    }
    
    private void Update()
    {
        OnMovement();
    }
    
    public void Damage(int damage) => HealthManager.TakeDamage(damage);
    
    private void OnDisable()
    {
        HealthManager.OnDied -= OnDeSpawned;
    }

    protected abstract void OnMovement();
}