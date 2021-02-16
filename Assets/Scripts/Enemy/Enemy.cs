using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, ITargetable
{
    [SerializeField] private EnemyMoveState _moveState;

    private Health _health;

    public event UnityAction<Enemy> Lost;

    public EnemyMoveState MoveState => _moveState;

    public Transform Transform => transform;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    public void BeAttacked(int damage)
    {
        _health.TakeDamage(damage);

        if(_health.HealthPoints <= 0)
        {
            Debug.Log("I Died");
            Lost?.Invoke(this);
        }
    }
}
