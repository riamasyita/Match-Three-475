using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    //Buat sambungin ke button lainnya 
    public GameFlowManager gameFlowManager;
    public Button buttonResume;
    public Button buttonRestart;
    public Button buttonExit;

    private void Awake()
    {
        gameFlowManager = GameFlowManager.Instance;
    }

    private void Start()
    {
        gameObject.SetActive(false);
        buttonResume.onClick.AddListener(gameFlowManager.ResumeGame);
        buttonRestart.onClick.AddListener(gameFlowManager.RestartGame);
        buttonExit.onClick.AddListener(gameFlowManager.ExitGame);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
