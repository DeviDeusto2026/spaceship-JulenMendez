using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainProject");
    }

    public void Ff()
    {
        Debug.Log("Prueba");
    }
}
