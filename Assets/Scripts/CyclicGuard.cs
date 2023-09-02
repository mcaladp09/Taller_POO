using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicGuard : AIPatrol
{
    private int currentPatrolIndex = 0;
    public float movementSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteProfile();
        DetectPlayer();
    }
   
    public override void ExecuteProfile()
    {
        Patrol();
    }

    public override void OnPlayerDetected()
    {
        Debug.Log("Player found");
    }

    public override void DetectPlayer()
    {
        if (!playerDetected)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, viewDistance);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    playerDetected = true;
                    OnPlayerDetected();
                    break;
                }
            } 
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        Vector3 moveDirection = (targetPoint.position - transform.position).normalized;

        transform.Translate(moveDirection * movementSpeed * Time.deltaTime);

        float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);
        if (distanceToTarget < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            if (currentPatrolIndex == 0)
            {
                currentPatrolIndex = 0;
            }
        }
    }
}
