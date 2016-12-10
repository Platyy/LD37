using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static float m_ShakeTimer;
    public static float m_ShakeAmount;

    private Vector3 m_initialPosition;
    private PauseMenu m_PauseMenu;

    private void Start()
    {
        m_PauseMenu = FindObjectOfType<PauseMenu>();

        m_initialPosition = transform.position;
    }

    private void Update()
    {
        Shake();
    }

    /// <summary>
    /// Handles camera shaking goodness
    /// Changes cameras position according to the shake amount until the shake timer is 0
    /// </summary>
    private void Shake()
    {
        if (m_ShakeTimer >= 0.0f)
        {
            m_initialPosition = transform.position;

            Vector3 shakePos = Random.insideUnitSphere*m_ShakeAmount*m_PauseMenu.GetShakeDamper();
            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z + shakePos.z);

            m_ShakeTimer -= Time.deltaTime;
        }
        if (m_ShakeTimer <= 0.0f)
        {
            m_ShakeAmount = 0.0f;
        }
    }

    /// <summary>
    /// Call this to apply screen shake
    /// </summary>
    /// <param name="_amount">Amount to shake (0-1 is the sweetspot)</param>
    /// <param name="_duration">Duration of shake (0-0.3 sweetspot)</param>
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
