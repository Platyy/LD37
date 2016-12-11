using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    public float m_PullForce = 5.0f;
    //public float m_PulledTimer
    public bool m_IsPulling = false;

    private void Update()
    {
        Pull();
    }

    private void Pull()
    {
        if (m_IsPulling)
        {
            Debug.Log("Pulling");
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
