using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Idle action")]
public class ActionIdle : Action {
    public override void DoAction(StateManager _stateManager) {
        _stateManager.transform.localEulerAngles = new Vector3(_stateManager.transform.localEulerAngles.x, _stateManager.transform.localEulerAngles.y + 5, _stateManager.transform.localEulerAngles.z);
        }
    }