using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //싱글톤 기본 형태
    static GameManager gameManager; //자기를 참조할 수 있는 static 변수
    public static GameManager Instance {get {return gameManager; }} // 그 변수를 외부로 가져갈 수 있는 프로퍼티 하나 

    private int currentScore = 0;
    private bool waitingToStart =false;

    UIManager uiManager;
    Player player;

    public UIManager UIManager {get {return uiManager; }}

    //가장 최초의 객체를 설정해주는 작업
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        player.gameObject.SetActive(false);
    }

    void Update()
    {
        if(waitingToStart && Input.GetKeyDown(KeyCode.Space))
        {
            waitingToStart =false;
            uiManager.restartText.gameObject.SetActive(false);
            player.gameObject.SetActive(true);
        }
    }

    public void ReadyToStartGame()
    {
        waitingToStart = true;
        uiManager.SetRestart();
    }

    public void GameOver()
    {
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재켜져 있는 Scene을 가져옴 
    }

    public void AddScore(int score)
    {
        currentScore +=score;
        Debug.Log("Score: "+currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
