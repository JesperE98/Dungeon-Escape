using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rb2D;
    private PlayerAnimation m_playerAnim;
    private SpriteRenderer m_playerSprite, m_swordArcRenderer;
    private bool m_resetJump = false, m_isGrounded = false, m_playerAttacked = false;
    
    [SerializeField] private LayerMask m_groundLayer;
    [SerializeField] private float m_jumpForce = 5.0f;
    [SerializeField] private float m_speed = 2.5f;


    private void Awake()
    {
        m_rb2D = GetComponent<Rigidbody2D>();
        m_playerAnim = GetComponent<PlayerAnimation>();
        m_playerSprite = GetComponentInChildren<SpriteRenderer>();
        m_swordArcRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerAttack();
    }

    // Funktion som gör att spelaren kan antingen gå höger/vänster när man klickar på tangenterna A/D och kan hoppa.
    private void PlayerMovement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        m_isGrounded = IsGrounded();

        if (move < 0f)
        {
            Flip(false);
        }
        else if (move > 0f)
        {
            Flip(true);

        }
                 

        if (Input.GetKey(KeyCode.Space) && IsGrounded() == true)
        {
            m_playerAnim.Jump(true);
            m_rb2D.velocity = new Vector2(m_rb2D.velocity.x, m_jumpForce);           
        }

        m_rb2D.velocity = new Vector2(move * m_speed, m_rb2D.velocity.y);
        m_playerAnim.Run(move);
    }

    // Funktion som kollar ifall spelaren är på backen eller inte.
    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.15f, m_groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 0.15f, Color.green);

        if (hitInfo.collider != null) 
        {
            
            if (m_resetJump == false) 
            {
                m_playerAnim.Jump(false);
                return true;
            }            
        }
        else if (hitInfo.collider == null) 
        {            
            return false; 
        }
        return false;
    }

    // Funktion som ser till att Player spriten är riktad åt hållet som spelaren går mot
    void Flip(bool faceRight)
    {
        if (faceRight == true) 
        { 
            m_playerSprite.flipX = false;
            m_swordArcRenderer.flipX = false;
            m_swordArcRenderer.flipY = false;

            Vector3 newPos = m_swordArcRenderer.transform.localPosition;
            newPos = new Vector3(1.01f, 1.09f, -0.25f);
            m_swordArcRenderer.transform.localPosition = newPos;
        }
        else if (faceRight == false) 
        { 
            m_playerSprite.flipX = true;
            m_swordArcRenderer.flipX = true;
            m_swordArcRenderer.flipY = true;

            Vector3 newPos = m_swordArcRenderer.transform.localPosition;
            newPos = new Vector3(-1.01f, 0.59f, -0.25f); 
            m_swordArcRenderer.transform.localPosition = newPos;
        }
    }

    // Funktion som initierar Attack Animationen genom AttackCooldownRoutine
    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded() == true) 
        {             
            StartCoroutine(AttackCooldownRoutine());
        }        
    }

    // Funktion som skapar en Attack cooldown för spelaren 
    IEnumerator AttackCooldownRoutine()
    {
        switch(m_playerAttacked)
        {
            case false:
                m_playerAnim.Attack();
                m_playerAttacked = true;
                break;

            case true:
                yield return new WaitForSeconds(0.5f);
                m_playerAttacked = false;
                break;
        }               
    }
}
