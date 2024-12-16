using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleteUI : MonoBehaviour
{
    
    public void LoadMainMenu() //fõmenü meghívás
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
