using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Slider m_ScreenShakeSlider;

    public Canvas MainCanvas;
    public GameObject OptionsPanel;

    private void Start()
    {
        MainCanvas.gameObject.SetActive(true);
        OptionsPanel.gameObject.SetActive(false);
    }

    public void BtnPlay()
    {
        SceneManager.LoadScene("LukesScene");
        SaveOptions();
    }

    public void BtnOptions()
    {
        //MainCanvas.gameObject.SetActive(false);
        OptionsPanel.gameObject.SetActive(true);
        Debug.Log("Open Options Menu");
    }

    public void BtnBack()
    {
        MainCanvas.gameObject.SetActive(true);
        OptionsPanel.gameObject.SetActive(false);
    }

    public void BtnQuit()
    {
        Application.Quit();
    }

    private void SaveOptions()
    {
        PlayerPrefs.SetFloat("ShakeValue", m_ScreenShakeSlider.value);
    }
}
