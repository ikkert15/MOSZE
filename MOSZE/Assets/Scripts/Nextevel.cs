using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalActivator : MonoBehaviour
{
    public GameObject portalObject;  // A portál objektum, amit aktiválunk
    public int requiredCoins = 2;    // A szükséges érme szám
    public string nextLevelSceneName = "Level2";  // A következõ szint neve (pl. Level2)
    private bool portalActive = false; // Portál aktiválása

    void Update()
    {
        // Ellenõrzi, hogy elértük-e a szükséges érmék számát
        if (Coin.coinCount >= requiredCoins && !portalActive)
        {
            portalActive = true;
            Debug.Log("Portal is now activated. Coins collected: " + Coin.coinCount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ha a játékos belép a portálba, és a megfelelõ számú érme megvan
        if (other.CompareTag("Player") && portalActive)
        {
            Debug.Log("Player is passing through the portal!");
            // Átirányítja a játékost a következõ szintre
            SceneManager.LoadScene(nextLevelSceneName);
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("You need more coins to pass through the portal.");
        }
    }
}

