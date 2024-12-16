using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Kilépés..."); 
        Application.Quit(); 
    }
}
