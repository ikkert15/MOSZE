using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 180f; // Forgási sebesség (180 fok/mp = 360 fok/2 mp)
    public static int coinCount = 0;  // Összegyûjtött coinok száma (statikus változó)

    void Update()
    {
        // Forgatás a Z tengely körül
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Ellenõrizzük, hogy a Player érte-e el a coint
        if (other.CompareTag("Player"))
        {
            coinCount++; // Coin számláló növelése
            Debug.Log("Coins collected: " + coinCount);

            Destroy(gameObject); // Coin eltávolítása a jelenetbõl
        }
    }
}
