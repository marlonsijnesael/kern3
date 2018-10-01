
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Coward/Orbit")]
public class ActionOrbitTarget : Action {

    public override void DoAction(StateManager _stateManager) {
        var varTransform = new GameObject().transform;
        Transform newTransform = varTransform;

        newTransform.RotateAround(_stateManager.chaseTarget.position, _stateManager.chaseTarget.transform.up, 50 * Time.deltaTime);
        newTransform.LookAt(_stateManager.chaseTarget);
        _stateManager.navMeshAgent.Move(newTransform.position);
        _stateManager.transform.rotation = newTransform.rotation;
        }


    
    }
