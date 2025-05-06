using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scorePanel;
    public static ScoreManager Instance { get; private set; }
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI isSuccessText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        scorePanel.SetActive(false);
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"{score}";
        if (bestScoreText != null)
            bestScoreText.text = $"{PlayerPrefs.GetInt("BestScore")}";
    }

    public void UpdateSuccessUI(bool isSuccess)
    {
        if (isSuccessText != null)
        {
            if (isSuccess)
                isSuccessText.text = $"SUCCESS >w<!!!";
            else
                isSuccessText.text = $"FAIL ㅜ.ㅜ!!!";
        }


    }

}
