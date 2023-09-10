using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform m_pointA, m_pointB;

    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Vector3 currentTarget;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) { return; }
        Movement();
    }

    public virtual void Movement()
    {

        if (currentTarget == m_pointA.position) { sprite.flipX = true; }
        else { sprite.flipX = false; }

        if (transform.position == m_pointA.position)
        {
            currentTarget = m_pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == m_pointB.position)
        {
            currentTarget = m_pointA.position;
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }


}
