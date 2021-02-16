using UnityEngine;

public class TargetFoundTransition : Transition
{
    private void OnEnable()
    {
        var state = (TowerFindTargetsState)CurrentState;
        state.TargetFound += OnTargetFound;
    }

    private void OnTargetFound(Enemy enemy)
    {
        NextState.SetTarget(enemy);
        SetTransit();
    }
}
