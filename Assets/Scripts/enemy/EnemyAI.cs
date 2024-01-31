using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 3f;
    public float detectionRange = 5f;
    private Transform player;
    public float turnSpeed = 2f;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                // If within attack range, attack the player
                if (distanceToPlayer <= attackRange)
                {
                    //AttackPlayer();
                    Debug.Log("attacks");
                }
                else
                {
                    // Move towards the player if not in attack range
                    MoveTowardsPlayer();
                }
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Adjust the enemy's rotation to look at the player
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    public int damageAmount = 10; // Adjust damage amount as needed

    //private void AttackPlayer()
    //{
    //    // Check if the player has a Health component
    //    Health playerHealth = player.GetComponent<Health>();

    //    if (playerHealth != null)
    //    {
    //        // Deal damage to the player
    //        playerHealth.TakeDamage(damageAmount);
    //    }
    //}
}


