using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KeeperController : MonoBehaviour{
    [SerializeField] AudioSource Heart1;
    [SerializeField] AudioSource Heart2;
    [SerializeField] GameObject gController;
     public Transform[] patrolPoints;
    public Transform player;
    public float detectionRange = 13f;
    public float heart1Range = 10f;
    public float heart2Range = 5f;
    public float loseRange = 1f;

    private NavMeshAgent agent;
    private int currentPointIndex = 0;
    private Animator animator;
    private bool isEnd = false;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    public void SetAnimationFinish(){
        animator.SetBool("canPunch", true);
        isEnd = true;
    }

    void Update(){
        if(!isEnd){
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);
            if (distanceToPlayer <= detectionRange){
                agent.SetDestination(player.position);

                if(distanceToPlayer > heart1Range){
                    if(!Heart1.isPlaying && !Heart2.isPlaying){Heart1.Play();}
                }

                else if(distanceToPlayer > heart2Range){
                    if(!Heart2.isPlaying && !Heart1.isPlaying){Heart2.Play();}
                }

                if(distanceToPlayer <= loseRange){
                    gController.GetComponent<LoseController>().StartFinishLoser();
                }
            }
            else{
                // Patrullar si el jugador está fuera del rango
                if (!agent.pathPending && agent.remainingDistance < 0.5f){
                    MoveToNextPoint();
                }
            }
        }
        else{
            CheeckAnimation();
        }
    }


    private void CheeckAnimation(){
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Hook Punch") && stateInfo.normalizedTime >= 1.0f){
            gController.GetComponent<LoseController>().SetAFinish();
        }
    }


    void MoveToNextPoint(){
        if (patrolPoints.Length == 0)
            return;
        agent.SetDestination(patrolPoints[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }
}
