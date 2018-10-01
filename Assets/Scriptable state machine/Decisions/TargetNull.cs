using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TargetNull")]
public class TargetNull : Decision {

    public override bool Decide(StateManager controller) {
        if (controller.chaseTarget == null) {
            return true;
            }
        return false;
        }

    }
