using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Rigidbody m_RB;
    public float m_ShotForce = 5.0f;

    private void Start()
    {
        m_RB = GetComponent<Rigidbody>();
        m_RB.AddForce(Vector3.up * m_ShotForce, ForceMode.Impulse);
    }
}