using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleteUI : MonoBehaviour
{
    
    public void LoadMainMenu() //f�men� megh�v�s
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
