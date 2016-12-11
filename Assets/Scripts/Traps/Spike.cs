using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Rigidbody m_RB;
    public float m_ShotForce = 5.0f;
    public float m_PushForce = 3.0f;

    private void Start()
    {
        m_RB = GetComponent<Rigidbody>();
        m_RB.AddForce(transform.parent.transform.up * m_ShotForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody _otherRB= other.GetComponent<Rigidbody>();
            if (!_otherRB)
            {
                _otherRB = other.GetComponentInParent<Rigidbody>();
                _otherRB.AddForce(transform.parent.transform.up * m_PushForce, ForceMode.Impulse);
            }
            other.GetComponentInParent<PlayerHealth>().Hurt();
            Destroy(this.gameObject);
        }
    }
}