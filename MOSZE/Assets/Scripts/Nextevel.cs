using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalActivator : MonoBehaviour
{
    public GameObject portalObject;  
    public int requiredCoins = 2;    
    public string nextLevelSceneName = "Level2";  
    private bool portalActive = false; 

    void Update()
    {
        
        if (Coin.coinCount >= requiredCoins && !portalActive)
        {
            portalActive = true;
            Debug.Log("portal aktiv�lva " + Coin.coinCount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && portalActive)
        {
            Debug.Log("Player nem ment �t a port�lon");
            Coin.ResetCoinCount();

            SceneManager.LoadScene(nextLevelSceneName);
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("SZ�ks�ges t�bb coin");
        }
    }
}

