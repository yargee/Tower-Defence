using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;   

    private Enemy _target;
    public Enemy Target => _target;   

    public void Enter()
    {        
        if (!enabled)
        {
            enabled = true;
            foreach (var transition in _transitions)
            {                
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {        
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.ResetNeedTransit();
                transition.enabled = false;
            }
            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {                
                return transition.NextState;
            }
        }
        return null;
    }

    public void SetTarget(Enemy target)
    {
        _target = target;
    }
    /*
    public void OnTargetLost(Enemy enemy)
    {
        Debug.Log(enemy.name + " DESTROYED");
        SetTarget(null);
    }*/
}
