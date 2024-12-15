using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private void Start()
    {
        
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
