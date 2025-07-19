using AbilitySystem;
using HealthSystem;
using Packages.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Useables.Weapons;

namespace PlayerControllers
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;
        
        [SerializeField] private Transform _barrelGunTransform;
        
        private InputAction _shootAction;
        private InputAction _rotateAction;

        private const float _startHealth = 10;
        private const int _startDamage = 1;
        private const float _startAttackSpeed = 0.4f;
        
        private readonly HealthManager _healthManager = new();
        private readonly Gun _primaryAbility = new();

        private void Start()
        {
            _healthManager.SetHealth(_startHealth);
            _primaryAbility.Init(_barrelGunTransform, _startDamage, _startAttackSpeed);
            
            InputManager.SubscribeToAction("Shoot", Shoot, out _shootAction);
            InputManager.SubscribeToAction("Rotate", RotateBarrel, out _rotateAction);
            
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

        public void Damage(int damage)
        {
            if (AbilityManager.Instance.GetShields() > 0)
            {
                return;
            }
            
            _healthManager.TakeDamage(damage);
        }

        private void Shoot(InputAction.CallbackContext _) => _primaryAbility.Use();

        private void RotateBarrel(InputAction.CallbackContext context)
        {
            Vector3 mousePosition = context.ReadValue<Vector2>();
            mousePosition.z = 10;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
            Vector2 direction = new (mousePosition.x - _barrelGunTransform.position.x, mousePosition.y - _barrelGunTransform.position.y);
            
            _barrelGunTransform.up = direction;
        }

        private void OnDestroy()
        {
            InputManager.UnsubscribeToAction(_shootAction, Shoot);
            InputManager.UnsubscribeToAction(_rotateAction, RotateBarrel);
        }
    }
}
