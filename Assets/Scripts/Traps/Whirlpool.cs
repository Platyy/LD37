using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    public float m_PullForce = 5.0f;
    public float m_TurnSpeed = 5.0f;
    public bool m_IsPulling = false;

    public float m_DeathRange = 0.3f;
    public float m_DeathTimer = 1.0f;
    public Transform m_DeathTrigger;

    private float m_DeathTime = 1.0f;

    private void Update()
    {
        Turn();
        //Pull();
        
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up, m_TurnSpeed*Time.deltaTime);
    }

    private void Pull()
    {
        if (m_IsPulling)
        {
            //Debug.Log("Pulling");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Collider[] cols = Physics.OverlapSphere(transform.position, GetComponent<SphereCollider>().radius);

        Vector3 forceDir = transform.position - other.transform.position;
        // other.GetComponentInParent<Rigidbody>().AddForce(forceDir.normalized * m_PullForce * Time.fixedDeltaTime, ForceMode.Impulse);

        //foreach (Collider col in cols)
        //{
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb = other.GetComponentInParent<Rigidbody>();
            if (rb != null)
            {
                m_IsPulling = true;
                rb.AddForce(forceDir.normalized * m_PullForce * Time.fixedDeltaTime, ForceMode.Acceleration);
                // Debug.Log(other.name);
                if (rb.tag == "Player")
                {
                    if (Vector3.Distance(m_DeathTrigger.position, rb.position) <= m_DeathRange)
                    {
                        m_DeathTimer -= Time.deltaTime;
                        if (m_DeathTimer <= 0.0f)
                        {
                            rb.GetComponent<PlayerHealth>().Kill();
                            m_DeathTimer = m_DeathTime;
                        }
                    }
                }
            }
        }
        //}

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_IsPulling = false;
        }
    }

    
}
