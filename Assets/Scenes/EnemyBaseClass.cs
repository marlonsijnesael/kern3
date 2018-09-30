using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// baseclass for enemies to derrive from
/// </summary>
public class EnemyBaseClass : MonoBehaviour {

    public enum EnemyStates {
        NULL,
        IDLE,
        CHASEBAIT,
        ALERT,
        CHASE,
        ATTACK,
        CONTENT,
        DEAD
        }

    public EnemyStates currentState;
    public int enemyHealth;
    public float moveSpeed, chaseSpeed;
    public float alertRadius, chaseDist, attackRadius;
    public float attackRate = 1f;
    public float nextAttack;

    public Rigidbody rigidBody2D;
    public GameObject playerObject;
   // public Slider enemyHealthSlider;

    protected bool findPlayer = true;

    public void Start() {
        currentState = EnemyStates.IDLE;
        rigidBody2D = gameObject.GetComponent<Rigidbody>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        //enemyHealthSlider.maxValue = enemyHealth;
     ///   enemyHealthSlider.value = enemyHealth;
        }

    public void Update() {
        if (findPlayer) {
            FindPlayer();
            }
        CheckHealth();
        //enemyHealthSlider.value = enemyHealth;
        }

    public virtual void TakeDamage(int amount) {
        enemyHealth -= amount;
        }

    public virtual void FindPlayer() {
        if (playerObject == null) {
            currentState = EnemyStates.IDLE;
            } else {
            float _distanceToPlayer = Vector3.Distance(playerObject.transform.position, transform.position);
            if (_distanceToPlayer < attackRadius) {
                currentState = EnemyStates.ATTACK;
                } else if (_distanceToPlayer < chaseDist) {
                currentState = EnemyStates.CHASE;
                } else if (_distanceToPlayer < alertRadius) {
                currentState = EnemyStates.ALERT;
                } else {
                currentState = EnemyStates.IDLE;
                }
            }
        }

    public virtual void CheckHealth() {
        Debug.Log(enemyHealth);
        if (enemyHealth <= 0) {
            currentState = EnemyStates.DEAD;
            Destroy(this.gameObject);
            }
        }

    public virtual void Attack() {
        if (Time.time > nextAttack) {

            nextAttack = Time.time + attackRate;

            }
        }
    }