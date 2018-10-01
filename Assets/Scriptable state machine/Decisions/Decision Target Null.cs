﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DecisionTargetNull : Decision {

    public override bool Decide(StateManager controller) {
        if (controller.chaseTarget == null) {
            return true;
            }
        return false;
        }

    }