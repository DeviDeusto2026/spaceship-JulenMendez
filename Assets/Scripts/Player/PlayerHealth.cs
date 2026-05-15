using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }


    private void Die()
    {
        SceneManager.LoadScene("DefeatScene");

    }

}
