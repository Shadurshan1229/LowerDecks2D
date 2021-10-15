using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberofFlashes;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");

            //iframes
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                GetComponent<Player_Movement>().enabled = false;
                dead = true;
            }
            

        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);

        //Invulnerability Duration
        for (int i = 0; i < numberofFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration/(numberofFlashes *3));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberofFlashes * 3));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
