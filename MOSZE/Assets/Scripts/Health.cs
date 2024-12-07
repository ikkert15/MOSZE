using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100; // A robot kezdõ életereje

    public void TakeDamage(int damage)
    {
        health -= damage; // Sebzés alkalmazása
        Debug.Log(gameObject.name + " took damage. Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject); // Objektum eltávolítása a jelenetbõl
    }
}
