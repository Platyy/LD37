using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerController m_Controller;

    public int m_Health = 8;
    public GameObject m_LostLeg;
    public GameObject[] m_Tentacles;

    private void Start()
    {
        m_Controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
    }

    /// <summary>
    /// Decreases player health, deactivates the leg
    /// </summary>
    public void Hurt()
    {
        // Shake it, baby.
        CameraShake.Shake(0.15f, 0.2f);

        // Create the lost leg.
        if (m_Health > 0)
        {
            GameObject lostLegGO = Instantiate(m_LostLeg, transform.position, Quaternion.identity);
        }
        Debug.Log("Hurt");
        
        // Decrease players health
        m_Health--;
        Debug.Log(m_Health);

        // TODO: This is hacky and bad. 
        // Loops through the legs and sets the legs at the index of our current health inactive
        //foreach (GameObject t in m_Tentacles)
        //{
        //    m_Tentacles[m_Health].SetActive(false);
        //}
        m_Controller.GetLegs(m_Health);

        // if we dead
        if (m_Health <= 0)
        {
            // die.
            Die();
            return;
        }
    }

    public void Kill()
    {
        for (int i = 0; i < m_Health; i++)
        {
            Hurt();
        }
    }

    /// <summary>
    /// Kill me.
    /// </summary>
    public void Die()
    {
        FindObjectOfType<CameraFollow>().m_Depth = -4.0f;
        m_Controller.m_IsDead = true;
        m_Controller.m_Ink.Play();
        Debug.Log("What do we do when we die?");
    }
}
