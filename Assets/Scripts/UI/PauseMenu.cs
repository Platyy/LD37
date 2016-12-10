using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuObject;
    public Slider m_ScreenShakeSlider;

    public static bool m_IsPaused;

    private void Start()
    {
        SetShakeDamperValue();
    }

    private void Update()
    {
        if (m_IsPaused && !PauseMenuObject.activeInHierarchy)
        {
            Time.timeScale = 0.0f;
            PauseMenuObject.SetActive(true);
        }
    }

    public void SetShakeDamperValue()
    {
        if(PlayerPrefs.HasKey("ShakeValue"))
            m_ScreenShakeSlider.value = PlayerPrefs.GetFloat("ShakeValue");
    }

    public float GetShakeDamper()
    {
        return m_ScreenShakeSlider.value;
    }

    public void BtnUnpause()
    {
        PauseMenuObject.SetActive(false);
        m_IsPaused = false;
        Time.timeScale = 1.0f;
    }
}