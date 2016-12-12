using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

    public GameObject m_WinText;
    public Transform m_WinParent;

    void OnTriggerEnter(Collider _col)
    {
        if(_col.tag == "Player")
        {
            Debug.Log("Player Win");
            _col.transform.root.transform.SetParent(m_WinParent);
            _col.transform.root.rotation = transform.rotation;
            _col.GetComponentInParent<PlayerController>().enabled = false;
            //m_WinText.SetActive(true);
        }
    }


}
