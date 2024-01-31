using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 10; // Adjust the damage amount as needed

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    // Check if the enemy has a Health component
        //    Health enemyHealth = collision.gameObject.GetComponent<Health>();

        //    // Destroy the enemy upon collision
        //    Destroy(collision.gameObject);
        //}
    }
}

