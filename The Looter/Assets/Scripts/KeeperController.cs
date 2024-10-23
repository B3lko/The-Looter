using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KeeperController : MonoBehaviour{
  public Transform[] patrolPoints;
    public Transform player;
    public float detectionRange = 10f;

    private NavMeshAgent agent;
    private int currentPointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Perseguir al jugador
            agent.SetDestination(player.position);
        }
        else
        {
            // Patrullar si el jugador está fuera del rango
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                MoveToNextPoint();
            }
        }
    }

    void MoveToNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        agent.SetDestination(patrolPoints[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }
}
