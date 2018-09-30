using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Decisions/Distance")]
public class DistanceDecision : Decision {

    public bool BiggerThanTarget;

    public int target;

    public override bool Decide(StateManager controller) {
        bool targetVisible = IsEnemyclose(controller);
        return targetVisible;
        }

    private bool IsEnemyclose(StateManager controller) {

        if (controller.chaseTarget == null) {
            return false;
            }
        float distToTarget = Vector3.Distance(controller.transform.position, controller.chaseTarget.transform.position);

        if (BiggerThanTarget) {
            if (distToTarget > target) {
                return true;
                }
            } else {
            if (distToTarget < target) {
                return true;
                }
            }
        return false;
        }


    }
