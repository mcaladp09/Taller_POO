using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIPatrol : MonoBehaviour
{
    public float viewDistance = 5f;
    public Transform[] waypoints; 
    public bool playerDetected = false;

    public abstract void ExecuteProfile();
    public abstract void OnPlayerDetected();
    public abstract void DetectPlayer();
}
