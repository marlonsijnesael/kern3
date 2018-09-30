using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : MonoBehaviour {

    public int health;
    public int attackDamage;
    public float nextAttack;
    public float attackRate;

    public void UpdateData() {
        Debug.Log(gameObject.name + " " + "health: " + health);
        if (health <= 0) {
            Destroy(this.gameObject);
            }
        }

    }
