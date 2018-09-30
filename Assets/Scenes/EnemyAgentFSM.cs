using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgentFSM : EnemyBaseClass {

    private Transform targetTransform;

    public Transform goal;
    UnityEngine.AI.NavMeshAgent agent;

    public GameObject raySpawn;

    new private void Start() {
        base.Start();
        currentState = EnemyStates.IDLE;
        goal = base.playerObject.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.ResetPath();
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
        CastRay();
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 5, transform.localEulerAngles.z);
        }

    public void ChaseBehaviour() {
        agent.destination = goal.position;
        transform.LookAt(goal.transform);
        FindPlayer();
        }


    public void CastRay() {
        Vector3 fwd = raySpawn.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(raySpawn.transform.position, fwd * 50, Color.green);
        if (Physics.Raycast(raySpawn.transform.position, fwd, out hit, 50)) {
            if (hit.transform.tag == "Player")
                Debug.Log(hit.transform.name);
                currentState = EnemyStates.CHASE;

            }
        }
        //state machine for lurker enemy
        private void StateMachine(EnemyStates state) {
        switch (state) {
            case EnemyStates.NULL:
                break;

            case EnemyStates.IDLE:
                IdleBahaviour();
                break;

            case EnemyStates.CHASE:
                ChaseBehaviour();
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
