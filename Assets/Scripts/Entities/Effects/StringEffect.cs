using AbilitySystem;
using UnityEngine;

public class StringEffect : Effect
{
    private void Start()
    {
        _text.text = "string"; 
    }
    
    protected override void OnAddEffect()
    {
        if (AbilityManager.Instance.AttackSpeedModifier == 400)
        {
            float newAttackSpeedModifier = AbilityManager.Instance.AttackSpeedModifier * 1.5f;
            AbilityManager.Instance.AttackSpeedModifier = (int) newAttackSpeedModifier;
        }
    }
}
