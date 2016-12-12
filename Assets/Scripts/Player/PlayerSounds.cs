using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource m_Source;
    public AudioClip m_SwimClip;
    public AudioClip m_JetClip;
    public AudioClip[] m_HurtClips;
    public AudioClip m_DieClip;

    private void Start()
    {
        if (m_Source == null)
        {
            Debug.LogError("No AudiSource Detected on player");
        }
    }

    public void PlayHurtSound()
    {
        m_Source.PlayOneShot(m_HurtClips[Random.Range(0, m_HurtClips.Length)]);
    }

    public void PlaySwimSound()
    {
        m_Source.PlayOneShot(m_SwimClip);
    }

    public void PlayJetSound()
    {
        m_Source.PlayOneShot(m_JetClip);
    }

    public void PlayDeathSound()
    {
        m_Source.volume = m_Source.volume/2;
        m_Source.PlayOneShot(m_DieClip);
    }
}
