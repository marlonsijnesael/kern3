using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgentFSM : EnemyBaseClass {

    private Transform targetTransform;

    public Transform goal;
    UnityEngine.AI.NavMeshAgent agent;



    new private void Start() {
        base.Start();
        currentState = EnemyStates.IDLE;
        goal = base.playerObject.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }


    new private void Update() {
        //check if agent is on navmash, otherwise reset position
        if (!agent.isOnNavMesh) {
            agent.Warp(transform.position);
            return;
            }

        FindPlayer();
        StateMachine(currentState);
        }

    //enemy is invulnerable in shadows
    public override void CheckHealth() {
        if (enemyHealth <= 0) {
            Destroy(this.gameObject);
            }
        }

    public override void TakeDamage(int amount) {
        base.TakeDamage(amount);
        }

    public void IdleBahaviour() {

        }


    //state machine for lurker enemy
    private void StateMachine(EnemyStates state) {
        switch (state) {
            case EnemyStates.NULL:
                break;

            case EnemyStates.IDLE:
                agent.SetPath(null);
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 1, transform.localEulerAngles.z);
                break;

            case EnemyStates.CHASE:
                agent.destination = goal.position;
                transform.LookAt(goal.transform);
                //EnemyMovement();
                break;

            case EnemyStates.ATTACK:
                targetTransform = null;
                Attack();
                break;


            default:
                break;
            }
        }



    }
