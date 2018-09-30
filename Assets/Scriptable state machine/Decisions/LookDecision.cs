using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision {

    public int radius;

    public override bool Decide(StateManager controller) {
        bool targetVisible = Look(controller);
        return targetVisible;
        }

    private bool Look(StateManager controller) {
        Vector3 fwd = controller.eyes.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(controller.eyes.transform.position, fwd * 50, Color.green);
        if (Physics.SphereCast(controller.eyes.transform.position,radius, fwd, out hit, 50)) {
            if (hit.transform.tag == "Player" || hit.transform.tag == "Agent")
                Debug.Log(hit.transform.name);
            controller.chaseTarget = hit.transform;
            return true;
            } else {
            return false;
            }

        }
    }
