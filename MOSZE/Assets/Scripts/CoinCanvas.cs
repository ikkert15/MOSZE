using UnityEngine;
using TMPro; 

public class CoinCounterUI : MonoBehaviour
{
    public TMP_Text coinText; 

    void Update()
    {
        coinText.text = "Coins: " + Coin.coinCount;
    }
}
