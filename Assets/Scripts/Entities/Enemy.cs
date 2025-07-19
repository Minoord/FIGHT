using PlayerControllers;
using UnityEngine;

public class Enemy : Entity
{
    protected override void OnMovement()
    {
       transform.position = Vector3.MoveTowards(transform.position, PlayerController.Instance.transform.position, Time.deltaTime * MovementSpeed);
    }
    
    protected void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.Damage(Strength);
        }
    }
}
