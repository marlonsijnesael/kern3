using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackMelee : Action {
   
    public override void DoAction(StateManager _stateManager) {
       
        if (Time.time > _stateManager.GetComponent<EntityData>().nextAttack && _stateManager.chaseTarget != null) {

            _stateManager.GetComponent<EntityData>().nextAttack = Time.time + _stateManager.GetComponent<EntityData>().attackRate;
            _stateManager.chaseTarget.GetComponent<EntityData>().health -= _stateManager.GetComponent<EntityData>().attackDamage;
            _stateManager.GetComponent<EntityData>().UpdateData();
            }
        }
    }
    
