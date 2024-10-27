using UnityEditor.Callbacks;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Player Died")]
    [SerializeField] private AudioClip playerDied;
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void Respawn()
    {
        dead = false;
        
        anim.ResetTrigger("die");
        anim.Play("idlee");
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");    
        }
        else
        {
            if (!dead)
            {
                SoundManager.instance.PlaySound(playerDied);
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                
            }
        }
    }
}
