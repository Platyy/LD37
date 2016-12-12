using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsToggle : MonoBehaviour
{
    public GameObject[] m_Traps;
    private bool m_TrapsOn = false;
    
    private void OnTriggerStay(Collider _other)
    {
        if(_other.tag == "Player" && m_TrapsOn == false)
        {
            foreach(GameObject go in m_Traps)
            {
                go.SetActive(true);
                m_TrapsOn = true;
            }
        }
    }

    private void OnTriggerExit (Collider _other)
    {
        if (_other.tag == "Player" && m_TrapsOn)
        {
            foreach (GameObject go in m_Traps)
            {
                go.SetActive(false);
                m_TrapsOn = false;
            }
        }

    }
        
}
