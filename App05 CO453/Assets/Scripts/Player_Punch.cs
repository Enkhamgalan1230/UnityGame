using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Punch : MonoBehaviour
{

    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 50;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    [SerializeField] private AudioSource hitSoundEffect;



    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time > nextAttackTime)
        {
            if (Input.GetKeyDown("f"))
            {
                Attack();
                hitSoundEffect.Play();
                nextAttackTime = Time.time +1f / attackRate;
            }

        }

    }


    private void Attack()

    {
          anim.SetTrigger("punch");

          Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

          foreach (Collider2D enemy in hitEnemies)
          {
              enemy.GetComponent<Enemyhealth>().TakeDamage(attackDamage);
          }
        
        
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
