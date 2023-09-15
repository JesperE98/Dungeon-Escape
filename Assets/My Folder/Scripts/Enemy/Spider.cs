using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    public GameObject m_acidEffectPrefab;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update()
    {

    }

    public void Damage()
    {
        if (isDead == true) { return; }

        health -= 25;

        if (health <= 0) 
        {
            FMODUnity.RuntimeManager.PlayOneShot(DeathEvent, transform.position);
            anim.SetTrigger("Death");
            isDead = true;
            GameObject diamond = Instantiate(gemPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }

    public void Attack()
    {
        Instantiate(m_acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
