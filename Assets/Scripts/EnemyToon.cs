using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyToon : MonoBehaviour
{
     [SerializeField] private PlayerScore playerScore;
    [SerializeField] private Animator animator;
    private NavMeshAgent meshAgent;
    private int number;
    [SerializeField] private float agentSuperSpeed;
    [SerializeField] GameObject[] patrolPoints;
    [SerializeField] 
    private PlayerController playerController;
    [SerializeField] 
    private GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        number = 0;

        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // we make the position of the agent in point 0
        meshAgent.destination = patrolPoints[number].transform.position;
        animator.SetBool("isWalk",true);
        agentSuperSpeed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        float dregonDistance = Vector3.Distance(player.transform.position, this.transform.position);
        if (dregonDistance<=25)
        {
            meshAgent.SetDestination(player.transform.position);
            animator.SetBool("isWalk",false);
            animator.SetBool("isRun",true);
        }

        if (dregonDistance < 2f)
        {
            meshAgent.transform.LookAt(player.transform.position);
            animator.SetBool("Attack", true);
            meshAgent.isStopped = true;
        }
        else
        {
            animator.SetBool("Attack", false);
            
            meshAgent.isStopped = false;   
        }
        
        if (!meshAgent.pathPending && meshAgent.remainingDistance<1)  {
            nextpoint();
            meshAgent.speed = 5;
            animator.SetBool("isWalk",true);
            animator.SetBool("Attack", false);

        }
    }

    public void nextpoint()
    {
        meshAgent.destination = patrolPoints[number].transform.position;
        number = (number + 1) % patrolPoints.Length;
    }

    public void run()
    {
        meshAgent.speed = agentSuperSpeed;

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Hand")
        {

           
            playerScore.scoreManger();
            //Destroy(this.gameObject);


        }

    }
}
