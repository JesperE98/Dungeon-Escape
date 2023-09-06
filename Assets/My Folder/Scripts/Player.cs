using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rb2D;

    private bool m_grounded = false;

    [SerializeField] private float floatHeight;
    [SerializeField] private float m_jumpForce = 1.0f;

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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = floatHeight - distance;
            float force = m_jumpForce * heightError + m_rb2D.velocity.y;
        }

        m_rb2D.velocity = new Vector2(horizontalInput, m_rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && m_grounded == true) 
        { 
            m_rb2D.velocity = new Vector2(m_rb2D.velocity.x, verticalInput); 

        }
        
    }
}
