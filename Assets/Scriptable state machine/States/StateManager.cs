using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateManager : MonoBehaviour {

    public State currentState;
    
    public Transform eyes;
    public State remainState;
   

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    public bool aiActive;


    void Awake() {
      
        navMeshAgent = GetComponent<NavMeshAgent>();
        }

    public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager) {
        wayPointList = wayPointsFromTankManager;
        aiActive = aiActivationFromTankManager;
        if (aiActive) {
            navMeshAgent.enabled = true;
            } else {
            navMeshAgent.enabled = false;
            }
        }

    void Update() {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
        }

    void OnDrawGizmos() {
        if (currentState != null && eyes != null) {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, 10);
            }
        }

    public void TransitionToState(State nextState) {
        if (nextState != remainState) {
            currentState = nextState;
            OnExitState();
            }
        }

    public bool CheckIfCountDownElapsed(float duration) {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
        }

    private void OnExitState() {
        stateTimeElapsed = 0;
        }
    }