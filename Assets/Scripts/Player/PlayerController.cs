﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

    public float m_MoveSpeed = 1f;
    public float m_JumpPower = 5f;
    public float m_MaxVelocity = 2f;
    public float m_RotationSpeed = 10f;

    public float m_DoubletapTime = 0.5f;
    private float m_DTRemaining;
    private int m_ButtonCount = 0;

    public Rigidbody m_RB;
    public GameObject m_Body;
    
    void Start()
    {
        //m_RB = GetComponent<Rigidbody>();
        m_DTRemaining = m_DoubletapTime;
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        //Move();
        Jump();
        //Dash();
        LookAtMouse();
        //m_RB.velocity = new Vector3(Mathf.Clamp(m_RB.velocity.x, -m_MaxVelocity, m_MaxVelocity), m_RB.velocity.y, m_RB.velocity.z);
    }

    void LookAtMouse()
    {
        //Get the Screen positions of the object
        Vector2 _positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 _mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float _angle = AngleBetweenTwoPoints(_positionOnScreen, _mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0f, 0f, _angle + 90)), Time.deltaTime * m_RotationSpeed);
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
            m_RB.AddForce(transform.up * m_JumpPower, ForceMode.Impulse);
            //transform.DOMove(transform.position + transform.up, 0.2f);
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

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
