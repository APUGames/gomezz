using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.0f;
    [SerializeField] float turnSpeed = 5.0f;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    NavMeshAgent nMa;
    void Start()
    {
        nMa = GetComponent<NavMeshAgent>();
        Physics.IgnoreCollision(target.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= nMa.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= nMa.stoppingDistance)
        {
            AttackTarget();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        nMa.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255f, 0f, 0f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}