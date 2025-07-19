using Ability.Weapons;
using HealthSystem;
using Packages.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControllers
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;
        
        [SerializeField] private Transform _barrelGunTransform;
        
        private readonly HealthManager _healthManager = new();
        private Gun _primaryAbility = new();
        private InputAction _shootAction;

        private const float _startHealth = 10;
        private const int _startDamage = 1;
        [SerializeField] private int _startAttackSpeed = 1;

        private void Start()
        {
            _healthManager.SetHealth(_startHealth);
            _primaryAbility.Init(_barrelGunTransform, _startDamage, _startAttackSpeed);
            InputManager.SubscribeToAction("Shoot", Shoot, out _shootAction);
            
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        
        public void Damage(int damage) => _healthManager.TakeDamage(damage);
        
        private void Shoot(InputAction.CallbackContext _) => _primaryAbility.Use();
        

        private void OnDestroy()
        {
            InputManager.UnsubscribeToAction(_shootAction, Shoot);
        }
    }
}
