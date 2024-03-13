using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovementMain : MonoBehaviour
{
    private Camera playCam;
    private NavMeshAgent unitAgent;
    public LayerMask groundPoint;
    
    //initialization du camera et l'unité
    private void Start()
    {
        playCam = Camera.main;
        unitAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitPoint;
            Ray rayPoint = playCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayPoint, out hitPoint, Mathf.Infinity, groundPoint))
            {
                unitAgent.SetDestination(hitPoint.point);
            }
        }
    }
}
