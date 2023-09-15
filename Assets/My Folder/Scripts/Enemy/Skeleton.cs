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
        if (isDead == true) { return; }
        FMODUnity.RuntimeManager.PlayOneShot(HitEvent, transform.position);
        health -= 25;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (health <= 0) 
        {
            FMODUnity.RuntimeManager.PlayOneShot(DeathEvent, transform.position);
            anim.SetTrigger("Death");
            isDead = true;
            GameObject diamond = Instantiate(gemPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
}
