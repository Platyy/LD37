using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkUI : MonoBehaviour
{
    private PlayerController m_Player;
    public Image m_InkImage;

    private float m_InkFillAmount;

    private void Start()
    {
        m_Player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        m_InkFillAmount = m_Player.GetBoostAmount();
        //Mathf.Clamp01(m_InkFillAmount);
        m_InkImage.transform.localScale = new Vector3(transform.localScale.x, Mathf.Clamp01(m_InkFillAmount), transform.localScale.z);
    }
}
