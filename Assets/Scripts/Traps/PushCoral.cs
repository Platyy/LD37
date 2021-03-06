﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCoral : MonoBehaviour {

    public float m_ForceAmount = 50f;

    public float m_BlowTime = 2f;
    public float m_DownTime = 5f;
    private float m_BlowTimeLeft;
    private float m_DownTimeLeft;

    private bool m_Blowing = false;

    public AudioSource m_Blow;

    public Animator m_Anim;

    public ParticleSystem m_Bubbles;

    void Start()
    {
        m_BlowTimeLeft = m_BlowTime;
        m_DownTimeLeft = m_DownTime;
    }

    void Update()
    {
        Blow();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && m_Blowing)
        {
            other.GetComponentInParent<Rigidbody>().AddForce(transform.forward * m_ForceAmount, ForceMode.Acceleration);
        }
    }

    void Blow()
    {
        if(!m_Blowing)
        {
            if(m_Bubbles.isPlaying)
                m_Bubbles.Stop();
            m_Anim.SetBool("Blowing", true);
            m_DownTimeLeft -= Time.deltaTime;
            if(m_DownTimeLeft <= 0)
            {
                m_DownTimeLeft = m_DownTime;
                m_Blowing = true;
            }
        }
        else
        {
            if (!m_Bubbles.isPlaying)
            {
                m_Bubbles.Play();
                m_Blow.Play();
                m_Anim.SetBool("Blowing", false);
            }
            m_BlowTimeLeft -= Time.deltaTime;
            if (m_BlowTimeLeft <= 0)
            {
                m_BlowTimeLeft = m_BlowTime;
                m_Blowing = false;
            }
        }
    }
}
