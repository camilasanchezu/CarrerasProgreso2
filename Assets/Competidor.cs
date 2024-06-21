using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Competidor : MonoBehaviour
{
    public NavMeshAgent agent;
    private GameObject player;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");

       
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
        
        if (agent != null && agent.isActiveAndEnabled && player != null)
        {
            // Asegúrate de que el agente esté en una superficie de NavMesh
            if (agent.isOnNavMesh)
            {
                agent.SetDestination(player.transform.position);
            }
            else
            {
                Debug.LogWarning("NavMeshAgent no está en una superficie de NavMesh.");
            }
        }
    }
}
