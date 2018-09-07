
using UnityEngine;
using StateClasses;

public class SecondState : State<FSMEnemyAI> {

    private static SecondState _instance;

    private SecondState() {
        if (_instance != null) {
            return;
            }

        _instance = this;
        }

    public static SecondState Instance {
        get {
            if (_instance == null) {
                new SecondState();
                }
            return _instance;
            }
        }


    public override void EnterState(FSMEnemyAI _o) {
        Debug.Log("entering second state");
        }

    public override void ExitState(FSMEnemyAI _o) {
        if (_o.switchState) {
            _o.StateMachine.ChangeState(FirstState.Instance);
            }
        }


    public override void UpdateState(FSMEnemyAI _o) {



        }
    }
