using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclicGuard : AIPatrol
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private List<Vector3> patrolPoints = new List<Vector3>();
    private int currentPatrolIndex = 0;

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
        Collider[] colliders = Physics.OverlapSphere(transform.position, viewDistance);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                OnPlayerDetected();
                break;
            }
        }
    }

    private void Patrol()
    {

    }
}
