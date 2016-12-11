using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

    public GameObject m_WinText;

    void OnTriggerEnter(Collider _col)
    {
        if(_col.tag == "Player")
        {
            Debug.Log("Player Win");
            _col.GetComponentInParent<PlayerController>().enabled = false;
            m_WinText.SetActive(true);
        }
    }


}
