using AbilitySystem;
using UnityEngine;

namespace Entities.Effects
{
    public class IntergerEffect : Effect
    {
        [SerializeField] private bool _isPositive;

        private int _randomNumber;
    
        protected override void OnEnable()
        {
            _randomNumber = Random.Range(0, 3);
            if (!_isPositive)
            {
                _randomNumber = -_randomNumber;
            }

            _text.text = $"{_randomNumber}"; 
            base.OnEnable();
        }
    
        protected override void OnAddEffect()
        {
            AbilityManager.Instance.StrengthModifier += _randomNumber;
        }
    }
}
