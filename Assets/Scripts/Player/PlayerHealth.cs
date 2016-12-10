using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int m_Health = 8;
    public GameObject m_LostLeg;
    public GameObject[] m_Tentacles;

    public void Hurt()
    {
        CameraShake.Shake(0.15f, 0.2f);
        //GameObject lostLegGO = Instantiate(m_LostLeg, transform.position, Quaternion.identity);
        Debug.Log("Hurt");
        m_Health--;
        Debug.Log(m_Health);
        foreach (GameObject t in m_Tentacles)
        {
            m_Tentacles[m_Health].SetActive(false);
        }
        if (m_Health <= 0)
        {
            Die();
            return;
        }
    }

    public void Die()
    {

        Debug.Log("What do we do when we die?");
    }
}
