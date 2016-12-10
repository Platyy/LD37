using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuObject;
    public Slider m_ScreenShakeSlider;

    private void Start()
    {
        SetShakeDamperValue();
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
    }
}