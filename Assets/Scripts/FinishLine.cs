using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [Header ("Player Win")]
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
            Invoke("LoadWinScene", playerWin.length);  // Delay scene load by the length of the clip
        
        }
        
    }
    private void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
}
