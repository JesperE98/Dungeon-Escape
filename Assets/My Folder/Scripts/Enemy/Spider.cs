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
        health -= 25;

        if (health <= 0) 
        {
            anim.SetTrigger("Death");
            isDead = true;
        }
    }

    public void Attack()
    {
        Instantiate(m_acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
