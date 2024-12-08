using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 180f; // Forg�si sebess�g (180 fok/mp = 360 fok/2 mp)
    public static int coinCount = 0;  // �sszegy�jt�tt coinok sz�ma (statikus v�ltoz�)

    void Update()
    {
        // Forgat�s a Z tengely k�r�l
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Ellen�rizz�k, hogy a Player �rte-e el a coint
        if (other.CompareTag("Player"))
        {
            coinCount++; // Coin sz�ml�l� n�vel�se
            Debug.Log("Coins collected: " + coinCount);

            Destroy(gameObject); // Coin elt�vol�t�sa a jelenetb�l
        }
    }
}
