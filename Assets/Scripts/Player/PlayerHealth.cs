using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int m_Health = 8;
    public GameObject m_LostLeg;
    public GameObject[] m_Tentacles;

    /// <summary>
    /// Decreases player health, deactivates the leg
    /// </summary>
    public void Hurt()
    {
        // Shake it, baby.
        CameraShake.Shake(0.15f, 0.2f);

        // Create the lost leg.
        //GameObject lostLegGO = Instantiate(m_LostLeg, transform.position, Quaternion.identity);
        Debug.Log("Hurt");
        
        // Decrease players health
        m_Health--;
        Debug.Log(m_Health);

        // TODO: This is hacky and bad. 
        // Loops through the legs and sets the legs at the index of our current health inactive
        foreach (GameObject t in m_Tentacles)
        {
            m_Tentacles[m_Health].SetActive(false);
        }
        // if we dead
        if (m_Health <= 0)
        {
            // die.
            Die();
            return;
        }
    }

    /// <summary>
    /// Kill me.
    /// </summary>
    public void Die()
    {

        Debug.Log("What do we do when we die?");
    }
}
