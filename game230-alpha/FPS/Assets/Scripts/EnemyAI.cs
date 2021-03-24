 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent nMa;
    // Start is called before the first frame update
    void Start()
    {
        nMa = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nMa.SetDestination(target.position);
    }
}
