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
    [SerializeField]
    protected GameObject gemPrefab;

    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Vector3 currentTarget;
    protected Diamond diamond;

    protected bool isHit = false;
    protected Player player;
    protected bool isDead = false;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        diamond = GetComponent<Diamond>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false) { return; }      
        if (isDead == false) { Movement(); }

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
        if (isHit == false) { transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime); }

        float distance = Vector3.Distance(transform.localPosition, player.transform.position);

        if (distance > 2.0f || player.Health < 1)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x < 0 && anim.GetBool("InCombat") == true) { sprite.flipX = true; }
        else if (direction.x > 0 && anim.GetBool("InCombat") == true) { sprite.flipX = false; }
    }
}
