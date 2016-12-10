using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float m_SmoothTime;
    public float m_Depth = -20.0f;
    private Vector3 m_RefVec = Vector3.zero;

    public Transform m_Player;

    void Update()
    {
        SetPosition();
    }

    void SetPosition()
    {
        Vector3 _target = m_Player.TransformPoint(new Vector3(0, 2, m_Depth));

        transform.position = Vector3.SmoothDamp(transform.position, _target, ref m_RefVec, m_SmoothTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 4, 12), transform.position.z);
    }

}
