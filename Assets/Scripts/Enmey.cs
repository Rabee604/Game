using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enmey : MonoBehaviour

{
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private Animator animator;
    private NavMeshAgent navMeshAgent;
    private int number;
    [SerializeField] 
    private PlayerController playerController;
    [SerializeField] 
    private float agentSuperSpeed; 
    [SerializeField] 
    private GameObject player;
    [SerializeField] GameObject[] patrolPoints;
   

   // Start is called before the first frame update


    

    void Start()
    {
        number = 0;
       
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // we make the position of the agent in point 0
        navMeshAgent.destination = patrolPoints[number].transform.position;
        //animator.SetBool("Attack",true);
        animator.SetFloat("EnemyS", 0.5f);
        agentSuperSpeed = 6;
      



    }

    // Update is called once per frame
    void Update()

    {
        
        

        // calculate
        float chase = Vector3.Distance(player.transform.position, this.transform.position);
        if (chase<= 11f && chase>4f)
        {
            Debug.Log("run");
            run();
            navMeshAgent.SetDestination(player.transform.position);
            
           
            animator.SetFloat("EnemyS", 1, 0.1f,Time.deltaTime);
            animator.SetBool("Attack", false);
           
        } float attack = Vector3.Distance(player.transform.position, this.transform.position);
        if (attack<=2f)
        {
            Debug.Log("Attack");
            navMeshAgent.SetDestination(player.transform.position);
            animator.SetBool("Attack", true);
           
        }
        
        if (playerController.isMove())
        {
            stopEnemy();
            animator.SetFloat("EnemyS", 0f);
            navMeshAgent.transform.LookAt(player.transform.position);
            Debug.Log("move");
        }
        else
        {
            navMeshAgent.isStopped = false;
        }


        float chase1 = Vector3.Distance(player.transform.position, this.transform.position);
        if (chase1 > 11f &&!playerController.isMove())
        {
            // go back to patrol
            navMeshAgent.SetDestination(patrolPoints[number].transform.position);
            Debug.Log("back patrol");
            animator.SetFloat("EnemyS", 0.5f);
            animator.SetBool("Attack", false);
        }
        


        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance<1)  {
            nextpoint();
            navMeshAgent.speed = 5;
            Debug.Log("patrol");
            Debug.Log(number);
            animator.SetFloat("EnemyS", 0.5f);
            animator.SetBool("Attack", false);

        }
    }

    public void nextpoint()
    {
        // we sure that we stay in array size
       /* if (number < patrolPoints.Length - 1)
        {
            number++;

        }
        else
        {
            number = 0;
        }*/
        
        //number = Random.Range(0, patrolPoints.Length);
        Debug.Log("Hej6");
        navMeshAgent.destination= patrolPoints[number].transform.position;
        number = (number + 1) % patrolPoints.Length;
    }

    public void run()
    {
        navMeshAgent.speed = agentSuperSpeed;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hand")
        {
            
            Debug.Log(other.gameObject.tag);
            playerScore.scoreManger();
            //Destroy(this.gameObject);
            
            
        }
        
    }

    public void stopEnemy()
    {

        navMeshAgent.isStopped = true;
    }

    public void disable()
    {
        navMeshAgent.enabled = false;
    }
}


