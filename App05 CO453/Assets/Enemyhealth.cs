using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;

    [SerializeField] private AudioSource ouchSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
        ouchSoundEffect.Play();

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        anim.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        

    }
}
