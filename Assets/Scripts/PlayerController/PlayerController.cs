using Ability.Weapons;
using HealthSystem;
using Packages.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        private readonly HealthManager _healthManager = new();
        private IAbility _primaryAbility = new Gun();
        private InputAction _shootAction;

        private const float _startHealth = 10;

        private void Start()
        {
            _healthManager.SetHealth(_startHealth);
            InputManager.SubscribeToAction("Shoot", Shoot, out _shootAction);
        }

        private void OnDestroy()
        {
            InputManager.UnsubscribeToAction(_shootAction, Shoot);
        }

        private void Shoot(InputAction.CallbackContext _) => _primaryAbility.Use();
    }
}
