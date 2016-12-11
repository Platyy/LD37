using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UrchinShooter : MonoBehaviour
{
    private Vector3 m_InitialScale;
    public Vector3 m_DesiredScale;
    public float m_DifferenceThreshold = 0.02f;
    public float m_AnimateTime;

    public bool m_Shooting = false;

    public GameObject m_SpikePrefab;

    private void Start()
    {
        m_InitialScale = transform.parent.localScale;
    }

    private void Update()
    {
        m_DesiredScale = new Vector3(m_DesiredScale.x, m_InitialScale.y + 1.0f, m_DesiredScale.z);
        if(!m_Shooting)
        {
            m_AnimateTime = 3.0f;
            transform.parent.DOScale(m_DesiredScale, m_AnimateTime);
            //Debug.Log(m_DesiredScale.x - transform.parent.localScale.x);
            if(m_DesiredScale.x - transform.parent.localScale.x <= m_DifferenceThreshold)
            {
                m_Shooting = true;
                Shoot();
            }
        }
        else
        {
            m_AnimateTime = 0.5f;
            transform.parent.DOScale(m_InitialScale, m_AnimateTime);
            if(transform.parent.localScale == m_InitialScale)
            {
                m_Shooting = false;
            }
        }
    }

    private void Shoot()
    {
        GameObject _spikeGO = Instantiate(m_SpikePrefab, transform.position, transform.rotation);
        Destroy(_spikeGO, 3.0f);
    }
}
