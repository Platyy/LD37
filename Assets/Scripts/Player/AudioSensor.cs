using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSensor : MonoBehaviour
{
    public float m_CheckRange = 5.0f;
    public float m_CheckTimer = 0.2f;

    private void Start()
    {
        Invoke("CheckRange", m_CheckTimer);
    }

    private void CheckRange()
    {
        CancelInvoke();

        Collider[] _objectInRange = Physics.OverlapSphere(transform.position, m_CheckRange);


        foreach (Collider col in _objectInRange)
        {
            AudioSource _source = col.GetComponent<AudioSource>();
            if (!_source)
            {
                _source = col.GetComponentInParent<AudioSource>();
                if (_source)
                {
                    _source.volume = 1.0f;
                }
            }
        }

        Invoke("CheckRange", m_CheckTimer);
    }

}
