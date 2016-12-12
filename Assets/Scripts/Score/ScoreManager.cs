using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public const string m_PrivateCode = "Us2kmZXWJEyZKWe0c5jOSgzr1zjZouk0OjrnG1v_8Ciw";
    public const string m_PublicCode = "584e27018af60302f8f9019e";
    public const string m_WebURL = "http://dreamlo.com/lb/";

    private ScoreUI m_ScoreDisplay;
    public Highscore[] m_HighscoreList;
    private static ScoreManager m_Instance;

    private float m_GameTimer = 0.0f;

    public float GetTimer()
    {
        return m_GameTimer;
    }

    private void Awake()
    {
        m_ScoreDisplay = GetComponent<ScoreUI>();
        m_Instance = this;
    }

    private void Start()
    {
        AddNewHighscore("Luke", 999999.0f);
        AddNewHighscore("Nick", 17.5f);
        AddNewHighscore("Jugg", 69.69f);

    }

    private void Update()
    {
        if (!PauseMenu.m_IsPaused)
        {
            m_GameTimer += Time.deltaTime;
        }
    }

    public static void AddNewHighscore(string _username, float _score)
    {
        m_Instance.StartCoroutine(m_Instance.UploadNewHighscore(_username, Mathf.RoundToInt(_score)));
    }

    private IEnumerator UploadNewHighscore(string _username, float _score)
    {
        WWW www = new WWW(m_WebURL + m_PrivateCode + "/add/" + WWW.EscapeURL(_username) + "/" + _score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload Successful");
            DownloadHighscore();
        }

        else
        {
            Debug.Log("Error Uploading: " + www.error);
        }
    }

    public void DownloadHighscore()
    {
        StartCoroutine(DownloadHighscores());
    }

    private IEnumerator DownloadHighscores()
    {
        WWW www = new WWW(m_WebURL + m_PublicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            System.Array.Reverse(m_HighscoreList);
            m_ScoreDisplay.OnHighscoresDownloaded(m_HighscoreList);
        }
        else
        {
            Debug.Log("Error Downloading: " + www.error);
        }
    }

    public void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        m_HighscoreList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; ++i)
        {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            float score = float.Parse(entryInfo[1]);
            m_HighscoreList[i] = new Highscore(username, score);
            Debug.Log(m_HighscoreList[i].Username + ": " + m_HighscoreList[i].Score);
        }
    }

    public struct Highscore
    {
        public string Username;
        public float Score;

        public Highscore(string _username, float _score)
        {
            Username = _username;
            Score = _score;
        }
    }
}
