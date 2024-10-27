using UnityEngine;

public class Enemy_attacc : MonoBehaviour
{
    [Header("Attack Sound")]
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            SoundManager.instance.PlaySound(attackSound);
        }
    }

}
