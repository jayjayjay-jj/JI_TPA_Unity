using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private Transform playerTrans, bearTrans;

    [SerializeField]
    private Animator bearAnimator;

    [SerializeField]
    private bool attackingPlayer;

    [SerializeField]
    private float range;

    [SerializeField]
    private PlayerStat playerStat;

    // Start is called before the first frame update
    void Start()
    {
        attackingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector3.Distance(playerTrans.position, bearTrans.position);
        Debug.Log(range);
        navMeshAgent.SetDestination(playerTrans.position);

        /*
        if(navMeshAgent.velocity.magnitude >= 0.1f)
        {
        */
        if(range <= 5f)
        {
            navMeshAgent.isStopped = true;
            bearAnimator.SetTrigger("Attack1");

            //         playerStat.damagetoHP(100);
            playerStat.currentHP -= 10;
            bearAnimator.SetBool("Run Forward", false);

        } else if(range > 5f && range <= 15f) 
        {
            navMeshAgent.isStopped = false;
            bearAnimator.SetBool("Run Forward", true);
          
        } else
        {
            bearAnimator.SetBool("Run Forward", false);
            bearAnimator.SetBool("Idle", true);
            navMeshAgent.isStopped = true;
        }
    }
}
