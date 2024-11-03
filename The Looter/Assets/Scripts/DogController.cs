using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour{
    [SerializeField] AudioSource bark;
    //[SerializeField] AudioSource Heart2;
    //[SerializeField] GameObject gController;
    public Transform[] patrolPoints;
    public Transform player;
    public float detectionRange = 13f;
    public float barkRange;
    //public float heart2Range = 5f;
    //public float loseRange = 1f;
    public GameObject keeper;

    private NavMeshAgent agent;
    private int currentPointIndex = 0;
    private Animator animator;
    private bool isEnd = false;
    private bool isBarking = false;
    public float rotationSpeed = 5f;
    private bool isPause = false;


    void Start(){
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
        animator = GetComponent<Animator>();
    }


    public void Bark0(){
        bark.volume = 0f;
    }

    /*public void SetAnimationFinish(){
        animator.SetBool("canPunch", true);
        isEnd = true;
    }*/

    void Update(){
        if(!isPause){

            if(!isEnd){
                float distanceToPlayer = Vector3.Distance(player.position, transform.position);
                if (distanceToPlayer <= detectionRange){
                    agent.SetDestination(player.position);
                    if(distanceToPlayer > barkRange){
                        if(!agent.isStopped){
                            agent.isStopped = true;
                        }
                        if(!isBarking){
                            isBarking = !isBarking;
                            animator.SetBool("isBarking", true);
                        }
                        if(!bark.isPlaying){
                            bark.Play();
                        }
                        RotateTowardsPlayer();
                        if(keeper){
                            if(!keeper.GetComponent<KeeperController>().GetDogBarking()){
                                keeper.GetComponent<KeeperController>().SetDogBarking(true);
                            }
                        }
                    }

                /* else if(distanceToPlayer > heart2Range){
                        if(!Heart2.isPlaying && !Heart1.isPlaying){Heart2.Play();}
                    }

                    if(distanceToPlayer <= loseRange){
                        gController.GetComponent<LoseController>().StartFinishLoser();
                    }*/
                }
                else{
                    if(keeper){
                        if(keeper.GetComponent<KeeperController>().GetDogBarking()){
                            keeper.GetComponent<KeeperController>().SetDogBarking(false);
                        }
                    }
                    if(agent.isStopped){
                        agent.isStopped = false;
                    }
                    if(isBarking){
                        if(bark.isPlaying){
                            bark.Stop();
                        }
                        isBarking = !isBarking;
                        animator.SetBool("isBarking", false);
                    }
                    // Patrullar si el jugador está fuera del rango
                    if (!agent.pathPending && agent.remainingDistance < 0.5f){
                        MoveToNextPoint();
                    }
                }
            }
        }
    }

    public void SetPause(){
        isPause = !isPause; // Alterna entre pausa y reanudación
        animator.speed = isPause ? 0 : 1;
        agent.isStopped = isPause; // Detener o reanudar el agente de navegación
        if(bark.isPlaying && isPause){
            bark.Stop();
        }
        if(isBarking && !isPause){
            bark.Play();
        }
    }


    void RotateTowardsPlayer(){
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }


    void MoveToNextPoint(){
        if (patrolPoints.Length == 0)
            return;
        agent.SetDestination(patrolPoints[currentPointIndex].position);
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }
}
