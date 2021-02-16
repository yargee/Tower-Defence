using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;    
    [SerializeField] private State _currentState;

    public State CurrentState => _currentState;

    private void FixedUpdate()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Start()
    {
        Reset(_firstState);
    }

    public void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter();
        }
    }

    public void Transit(State nextState)
    {        
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter();
        }
    }
}
