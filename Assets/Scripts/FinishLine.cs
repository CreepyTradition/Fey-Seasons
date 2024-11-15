using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [Header("Player Win")]
    [SerializeField] private AudioClip playerWin;

    void Start()
    {
        Debug.Log("SceneChanger script started.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You win.");
            SoundManager.instance.PlaySound(playerWin);
            Invoke("LoadNextScene", playerWin.length);
        }
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 4)
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
