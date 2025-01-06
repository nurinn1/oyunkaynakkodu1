using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Oyun sahnesine ge�i� yapar
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        // Oyundan ��k�� yapar
        Debug.Log("Oyun kapat�l�yor...");
        Application.Quit();
    }
}
