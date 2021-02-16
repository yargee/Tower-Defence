using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField] private Enemy _currentTarget;
    [SerializeField] private TargetsPool nearestTargets;

    public void SetTarget(Enemy target)
    {
        _currentTarget = target;
    }


}
