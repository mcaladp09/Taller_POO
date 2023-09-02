using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIPatrol : MonoBehaviour
{
    public float viewDistance = 10f;
    public abstract void ExecuteProfile();
    public abstract void OnPlayerDetected();
    public abstract void DetectPlayer();
}
