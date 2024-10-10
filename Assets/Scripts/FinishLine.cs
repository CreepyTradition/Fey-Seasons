using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void Start()
    {
        Debug.Log("SceneChanger script started.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You win.");
            SceneManager.LoadScene("WinScene");
        }
    }
}
