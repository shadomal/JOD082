using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [Header("NavMashComponents")]
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private GameObject playerObj;
    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }
    public void trackPlayer() => enemyAgent.SetDestination(playerObj.transform.position);

}
