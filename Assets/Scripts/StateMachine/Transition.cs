using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _currentState;
    [SerializeField] private State _nextState;


    protected ITargetable Target;

    public State NextState => _nextState;
    public State CurrentState => _currentState;

    public bool NeedTransit { get; protected set; }
    
    public void Init(ITargetable target)
    {
        Target = target;
    }
    public void ResetNeedTransit()
    {
        NeedTransit = false;
    }

    protected void SetTransit()
    {        
        NeedTransit = true;
        enabled = false;
    }
}
