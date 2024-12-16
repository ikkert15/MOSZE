using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public static int coinCount = 0;

    void Update()
    {
        
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            coinCount++;
            Debug.Log("Coins collected: " + coinCount);

            Destroy(gameObject);
        }
    }

    
    public static void ResetCoinCount()
    {
        coinCount = 0;
        Debug.Log("Coin számláló nullázva!");
    }
}