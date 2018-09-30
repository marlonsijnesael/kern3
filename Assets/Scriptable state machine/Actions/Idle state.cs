using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Idle")]
public class Idlestate : Action {

    public override void DoAction(StateManager controller) {
        controller.transform.localEulerAngles = new Vector3(controller.transform.localEulerAngles.x, controller.transform.localEulerAngles.y + 5, controller.transform.localEulerAngles.z);
       // controller.TransitionToState(controller.currentState.possibleStates[0]);
        }


    }
