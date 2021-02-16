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

        //if (CurrentState.Target != null && NextState.Target == null)
        //  {
        //CurrentState.Target.Lost += CurrentState.OnTargetLost;

        //  }
    }
}
