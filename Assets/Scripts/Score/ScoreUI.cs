using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text m_TimerTxt;

    public Text[] m_HighscoreFields;
    ScoreManager m_Scores;

    private void Start()
    {
        for (int i = 0; i < m_HighscoreFields.Length; ++i)
        {
            m_HighscoreFields[i].text = i + 1 + ". Fetching";
        }

        m_Scores = GetComponent<ScoreManager>();
        StartCoroutine(RefreshHighscores());
    }

    void Update()
    {
        m_TimerTxt.text = "Time: " + m_Scores.GetTimer().ToString("N0") + "s";
    }

    public void OnHighscoresDownloaded(ScoreManager.Highscore[] _highscoreList)
    {
        for (int i = 0; i < m_HighscoreFields.Length; ++i)
        {
            m_HighscoreFields[i].text = i + 1 + ". ";
            if (i < _highscoreList.Length)
            {
                m_HighscoreFields[i].text += _highscoreList[i].Username + " - " + _highscoreList[i].Score + "s";
            }
        }
    }

    private IEnumerator RefreshHighscores()
    {
        while (true)
        {
            m_Scores.DownloadHighscore();
            yield return new WaitForSeconds(30.0f);
        }
    }

}
