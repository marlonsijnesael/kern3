// MoveTo.cs
using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

    public Transform goal;
    UnityEngine.AI.NavMeshAgent agent;
    void Start() {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
        }
    private void Update() {
        float dist = Vector3.Distance(goal.position, transform.position);
        if (dist < 15)
            agent.destination = goal.position;
        }
    }