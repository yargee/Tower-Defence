using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : State
{
    [SerializeField] private float _speed;

    private Transform[] _route;
    private int _wayPointIndex;

    private void Update()
    {
        Move();
    }

    public void SetRoute(Transform[] route)
    {
        _route = route;
        _wayPointIndex = 0;
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _route[_wayPointIndex].position, _speed * Time.deltaTime);

        if (transform.position == _route[_wayPointIndex].position)
        {
            SetNewWaypoint();
        }
    }

    private void SetNewWaypoint()
    {
        if (_wayPointIndex != _route.Length - 1)
        {
            _wayPointIndex++;
        }
    }
}
