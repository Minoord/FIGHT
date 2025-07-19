using AbilitySystem;
using UnityEngine;

public class BoolEffect : Effect
{
    [SerializeField] private bool _shouldEnable;
    
    private void Start()
    {
        _text.text = $"{_shouldEnable}"; 
    }
    
    protected override void OnAddEffect()
    {
        AbilityManager.Instance.IsAbilityEnabled = _shouldEnable;
    }
}
