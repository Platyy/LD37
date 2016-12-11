using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    private Transform m_Player;

    public bool m_IsRunningAway;
    public float m_SightDistance;
    public float m_MoveSpeed;

    private void Start()
    {
        if (!m_Player)
        {
            m_Player = FindObjectOfType<PlayerController>().transform;
        }
    }

    private void Update()
    {
        m_IsRunningAway = Vector3.Distance(transform.position, m_Player.position) < m_SightDistance;
    }

    private void FixedUpdate()
    {
        if (m_IsRunningAway)
        {
            Vector3 _move = transform.position - m_Player.position;
            transform.Translate(_move.normalized*m_MoveSpeed*Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate((transform.position + Random.insideUnitSphere)*m_MoveSpeed*Time.fixedDeltaTime);
        }
    }

    //private float Ease(float x)
    //{
    //    float a = m_EaseAmount + 1.0f;
    //    return Mathf.Pow(x, a)/(Mathf.Pow(x, a) + Mathf.Pow(1.0f - x, a));
    //}
}
