using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100; 

    public void TakeDamage(int damage)
    {
        health -= damage; 
        Debug.Log(gameObject.name + " took damage. Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject); 
    }
}
