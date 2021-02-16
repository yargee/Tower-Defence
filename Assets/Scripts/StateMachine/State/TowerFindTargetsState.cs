using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerFindTargetsState : State
{
    [SerializeField] private Enemy _currentTarget;
    [SerializeField] private TargetsPool Targets;

    public event UnityAction<Enemy> TargetFound;

    private void FixedUpdate()
    {
        FindNewTargets();
    }

    private void FindNewTargets()
    {
        if (Targets.Count() == 0)
        {            
            return;
        }
        
        var newTarget = Targets.GetTarget();
        _currentTarget = newTarget;
        TargetFound?.Invoke(newTarget);
    }
}
