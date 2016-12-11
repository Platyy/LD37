using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{

    public AudioClip[] m_MusicClips;

    private AudioSource m_Source;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        SceneManager.LoadScene("MenuScene");
        m_Source = GetComponent<AudioSource>();

        ChangeSong();
    }

    private void Update()
    {
        if (!m_Source.isPlaying)
        {
            ChangeSong();
        }
    }

    private void ChangeSong()
    {
        m_Source.clip = m_MusicClips[Random.Range(0, m_MusicClips.Length)];

        m_Source.Play();
    }

}
