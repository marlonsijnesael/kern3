using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateClasses;

public class FSMEnemyAI : MonoBehaviour {

    public float rotationSpeed;
    public GameObject raySpawn;


    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0;

    public StateMachine<FSMEnemyAI> StateMachine { get; set; }

    private void Start() {
        StateMachine = new StateMachine<FSMEnemyAI>(this);
        StateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;
        }

    public void Update() {
        
       // CastRay();
        
        //Timer();
        StateMachine.Update();
        }


    public void CastRay() {
        Vector3 fwd = raySpawn.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(raySpawn.transform.position, fwd * 50, Color.green);
        if (Physics.Raycast(raySpawn.transform.position, fwd, out hit, 50)) {
            if (hit.transform.name == "Player") 
                Debug.Log(hit.transform.name);
      
            }
      
    }

    private void Timer() {
        if (Time.time > gameTimer + 1) {
            gameTimer = Time.time;
            seconds++;
            Debug.Log(seconds);
            }

        if (seconds == 5) {
            seconds = 0;
            switchState = !switchState;
            }

        }
    }
