using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {      
        print("Damage()");
        health -= 25;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (health <= 0) 
        {
            anim.SetTrigger("Death");
            isDead = true;
        }

        Debug.Log(health);
    }
}
