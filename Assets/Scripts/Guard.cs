using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : AIPatrol
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private float rotationTimer = 0f;
    private float rotationInterval = 3f;

    public override void ExecuteProfile()
    {
        // Guardia estático, implementa su lógica de rotación aquí
        RotateGuard();
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

    private void RotateGuard()
    {
        rotationTimer += Time.deltaTime;
        if (rotationTimer >= rotationInterval)
        {
            transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
            rotationTimer = 0f;
        }
    }
}
