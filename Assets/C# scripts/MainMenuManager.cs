using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Oyun sahnesine geçiþ yapar
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        // Oyundan çýkýþ yapar
        Debug.Log("Oyun kapatýlýyor...");
        Application.Quit();
    }
}
