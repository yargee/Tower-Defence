﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerAttackState : State
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Enemy _currentTarget;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _fireDistance;

    private float _distanceToTarget;
    private float _timeBetweenAttacks;

    public void ResetTarget()
    {
        _currentTarget = Target;
    }

    public event UnityAction TargetLost;

    private void OnEnable()
    {
        Target.Lost += OnTargetLost;
        _timeBetweenAttacks = _attackDelay / 2;
        _currentTarget = Target;
    }

    private void FixedUpdate()
    {
        if (Target == null)
        {
            TargetLost?.Invoke();
            return;
        }

        _timeBetweenAttacks += Time.deltaTime;

        if (_timeBetweenAttacks >= _attackDelay)
        {
            _timeBetweenAttacks = 0;

            if (Target != null && FireDistance())
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        var bullet = Instantiate(_bulletTemplate, transform.position, Quaternion.identity);
        if (Target != null)
        {
            bullet.Init(Target);
        }
    }

    private bool FireDistance()
    {
        if (Target != null)
        {
            _distanceToTarget = Vector3.Distance(transform.position, Target.Transform.position);

            if (_distanceToTarget <= _fireDistance)
            {
                return true;
            }
            else
            {
                TargetLost?.Invoke();
                return false;
            }
        }
        return false;
    }

    public void OnTargetLost(Enemy enemy)
    {
        SetTarget(null);
        ResetTarget();
        TargetLost?.Invoke();
    }
}
