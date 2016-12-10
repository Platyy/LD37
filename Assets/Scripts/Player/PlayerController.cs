using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

    public float m_MoveSpeed = 1f;
    public float m_JumpPower = 5f;
    public float m_MaxVelocity = 2f;

    public float m_DoubletapTime = 0.5f;
    private float m_DTRemaining;
    private int m_ButtonCount = 0;

    private Rigidbody m_RB;
    private Vector3 m_CurrentPosition;

    
    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
        m_DTRemaining = m_DoubletapTime;
    }

    void FixedUpdate()
    {
        Move();
        Jump();
        Dash();
        m_RB.velocity = new Vector3(Mathf.Clamp(m_RB.velocity.x, -m_MaxVelocity, m_MaxVelocity), m_RB.velocity.y, m_RB.velocity.z);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A)) // Left
        {
            m_RB.velocity = new Vector3(m_RB.velocity.x - m_MoveSpeed, m_RB.velocity.y, m_RB.velocity.z);
        }
        if(Input.GetKey(KeyCode.D)) // Right
        {
            m_RB.velocity = new Vector3(m_RB.velocity.x + m_MoveSpeed, m_RB.velocity.y, m_RB.velocity.z);
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_RB.velocity = new Vector3(m_RB.velocity.x, m_RB.velocity.y + m_JumpPower, m_RB.velocity.z);
        }
    }

    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(m_DTRemaining >= 0 && m_ButtonCount == 1)
            {
                Debug.Log("Dashed");
                transform.DOMoveX(transform.position.x - 2, 0.2f);
                m_DTRemaining = m_DoubletapTime;
            }
            else
            {
                m_DTRemaining = m_DoubletapTime;
                m_ButtonCount += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (m_DTRemaining >= 0 && m_ButtonCount == 1)
            {
                Debug.Log("Dashed");
                transform.DOMoveX(transform.position.x + 2, 0.2f);
                m_DTRemaining = m_DoubletapTime;
            }
            else
            {
                m_DTRemaining = m_DoubletapTime;
                m_ButtonCount += 1;
            }
        }

        if (m_DTRemaining >= 0)
        {
            m_DTRemaining -= Time.deltaTime;
        }
        else
        {
            m_ButtonCount = 0;
        }
    }

}
