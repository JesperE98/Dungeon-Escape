using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rb2D;
    [SerializeField] private bool m_grounded = false;

    [SerializeField] private float m_jumpForce = 5.0f;

    private void Awake()
    {
        m_rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        m_rb2D.velocity = new Vector2(horizontalInput, m_rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && m_grounded == true) 
        {           
            m_rb2D.velocity = new Vector2(m_rb2D.velocity.x, m_jumpForce);
        }


        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, 1 << 6);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hitInfo.collider != null)
        {
            Debug.Log("Hit!: " + hitInfo.collider.name);
            m_grounded = true;
        }
        else if (hitInfo.collider == null)
        {
            m_grounded = false;
        }
        

    }
}
