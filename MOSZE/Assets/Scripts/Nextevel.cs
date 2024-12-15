using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalActivator : MonoBehaviour
{
    public GameObject portalObject;  // A port�l objektum, amit aktiv�lunk
    public int requiredCoins = 2;    // A sz�ks�ges �rme sz�m
    public string nextLevelSceneName = "Level2";  // A k�vetkez� szint neve (pl. Level2)
    private bool portalActive = false; // Port�l aktiv�l�sa

    void Update()
    {
        // Ellen�rzi, hogy el�rt�k-e a sz�ks�ges �rm�k sz�m�t
        if (Coin.coinCount >= requiredCoins && !portalActive)
        {
            portalActive = true;
            Debug.Log("Portal is now activated. Coins collected: " + Coin.coinCount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ha a j�t�kos bel�p a port�lba, �s a megfelel� sz�m� �rme megvan
        if (other.CompareTag("Player") && portalActive)
        {
            Debug.Log("Player is passing through the portal!");
            // �tir�ny�tja a j�t�kost a k�vetkez� szintre
            SceneManager.LoadScene(nextLevelSceneName);
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("You need more coins to pass through the portal.");
        }
    }
}

