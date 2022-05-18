using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent _navMeshAgent;
    public Transform[] _waypoints;

    int m_currentWaypointIndex;

    void Start()
    {
        _navMeshAgent.SetDestination(_waypoints[0].position);
    }

    void Update()
    {
        if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
        {
            m_currentWaypointIndex = (m_currentWaypointIndex + 1) % _waypoints.Length;
            _navMeshAgent.SetDestination(_waypoints[m_currentWaypointIndex].position);
        }
    }
}
