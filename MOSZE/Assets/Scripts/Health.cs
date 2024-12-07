using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100; // A robot kezd� �letereje

    public void TakeDamage(int damage)
    {
        health -= damage; // Sebz�s alkalmaz�sa
        Debug.Log(gameObject.name + " took damage. Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject); // Objektum elt�vol�t�sa a jelenetb�l
    }
}
