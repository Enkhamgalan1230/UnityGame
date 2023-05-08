using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;


    private void Start()

    {
      
        anim = GetComponent<Animator>();
       
    }
    
    private void Update()
    {

       
        if(Input.GetKeyDown("f"))
        {

            Attack();

        }
    }


    public void Attack()
    {
        anim.SetTrigger("punch");

    }
}
