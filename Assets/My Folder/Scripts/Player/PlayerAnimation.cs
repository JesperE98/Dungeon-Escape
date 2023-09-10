using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_spriteAnim;
    private Animator m_swordArcAnim;

    void Start()
    {
        m_spriteAnim = GameObject.Find("Sprite").GetComponent<Animator>();
        m_swordArcAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Run(float move)
    {
        m_spriteAnim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        m_spriteAnim.SetBool("Jump", jumping);
    }

    public void Attack()
    {
        m_spriteAnim.SetTrigger("Attack");
        m_swordArcAnim.SetTrigger("SwordAnimation");
    }

    public void JumpAttack()
    {
        m_spriteAnim.SetTrigger("Jump Attack");
    }
}
