using TMPro;
using UnityEngine;

public abstract class Effect : Entity
{
    [SerializeField] protected TMP_Text _text;

    protected override void OnMovement()
    {
        Vector3 direction = -transform.up * MovementSpeed * Time.deltaTime;
        transform.position += direction;
    }

    protected override void OnDeSpawned()
    {
        OnAddEffect(); 
        OnDespawn?.Invoke(ID, this);  
    } 
    
    protected abstract void OnAddEffect();
}
