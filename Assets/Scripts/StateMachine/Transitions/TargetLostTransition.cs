using UnityEngine;
using UnityEngine.Events;

public class TargetLostTransition : Transition
{
    private void OnEnable()
    {
        var state = (TowerAttackState)CurrentState;
        state.TargetLost += OnTargetLost;
    }

    public void OnTargetLost()
    {
        SetTransit();
    }
}
