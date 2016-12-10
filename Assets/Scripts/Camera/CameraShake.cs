using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static float m_ShakeTimer;
    public static float m_ShakeAmount;

    private Vector3 m_initialPosition;

    private void Start()
    {
        m_initialPosition = transform.position;
    }

    private void Update()
    {
        Shake();
    }

    private void Shake()
    {
        if (m_ShakeTimer >= 0.0f)
        {
            m_initialPosition = transform.position;
            Vector3 shakePos = Random.insideUnitSphere*m_ShakeAmount;
            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z + shakePos.z);

            m_ShakeTimer -= Time.deltaTime;
        }
        if (m_ShakeTimer <= 0.0f)
        {
            m_ShakeAmount = 0.0f;
        }
    }

    public static void Shake(float _amount, float _duration)
    {
        if (m_ShakeAmount > _amount)
        {
            // If the current screen shake amount is greater than the new one,
            // bail. We don't want to emphasize something small when something big is happening
            return;
        }
        m_ShakeAmount = _amount;
        m_ShakeTimer = _duration;
    }
}
