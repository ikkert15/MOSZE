using UnityEngine;
using TMPro; // TextMeshPro namespace

public class CoinCounterUI : MonoBehaviour
{
    public TMP_Text coinText; // TextMeshPro t�mogat�s

    void Update()
    {
        coinText.text = "Coins: " + Coin.coinCount;
    }
}
