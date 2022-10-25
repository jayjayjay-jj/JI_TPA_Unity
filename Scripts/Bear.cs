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

    private bool attackingPlayer;

    private float range;

    [SerializeField]
    private PlayerStat playerStat;

    public AudioSource bearAttackAudio;

    // Start is called before the first frame update
    void Start()
    {
        bearAttackAudio = GetComponent<AudioSource>();

        attackingPlayer = false;
        bearAttackAudio.enabled = false;
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
        if(range <= 2f)
        {
            navMeshAgent.isStopped = true;
            bearAnimator.SetBool("Run Forward", false);
            
            attack();

        } else if(range > 2f && range <= 15f) 
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
    void attack()
    {
        bearAnimator.SetTrigger("Attack1");
        bearAttackAudio.enabled = false;
        playerStat.damagetoHP(1);
        bearAttackAudio.enabled = true;
    }
}
