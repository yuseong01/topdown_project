using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionUI : MonoBehaviour
{
    public GameObject instructionPanel;

    public void OnClickStart()
    {
        instructionPanel.SetActive(false);
        GameManager.Instance.ReadyToStartGame();
    }
    public void OnClickExit()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
