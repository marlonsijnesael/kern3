
using UnityEngine;
using StateClasses;


/// <summary>
/// Idle state, enemy scans
/// </summary>
public class FirstState : State<FSMEnemyAI> {

    private static FirstState _instance;

    private FirstState() {
        if (_instance != null) {
            return;
            }

        _instance = this;
        }

    public static FirstState Instance {
        get {
            if (_instance == null) {
                new FirstState();
                }
            return _instance;
            }
        }
    

    public override void EnterState(FSMEnemyAI _o) {
        Debug.Log("entering first state");
        }

    public override void ExitState(FSMEnemyAI _o) {
        Debug.Log("exiting first state");
        }

    public override void UpdateState(FSMEnemyAI _o) {
        if (_o.switchState) {
            _o.StateMachine.ChangeState(SecondState.Instance);
            }
        _o.transform.localEulerAngles = new Vector3(_o.transform.localEulerAngles.x, _o.transform.localEulerAngles.y + _o.rotationSpeed, _o.transform.localEulerAngles.z);
        _o.CastRay();
        //  _o.transform.position
        }


    }
