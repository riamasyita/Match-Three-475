using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    [Header("UI")]
    public UIGameOver GameOverUI;
    public UIPauseMenu PauseMenuUI;

    public void GameOver()
    {
        isGameOver = true;
        ScoreManager.Instance.SetHighScore();
        GameOverUI.Show();
    }

    #region Singleton

    private static GameFlowManager _instance = null;

    public static GameFlowManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameFlowManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: GameFlowManager not Found");
                }
            }

            return _instance;
        }
    }

    #endregion

    public bool IsGameOver { get { return isGameOver; } }

    private bool isGameOver = false;

    private void Start()
    {
        isGameOver = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; //bikin skala waktu jadi 0 biar game berhenti
        PauseMenuUI.Show();
        SoundManager.Instance.PlayPause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; //set skala waktu jadi 1 biar lanjut lagi
        PauseMenuUI.Hide();
    }

    public void RestartGame()
    {
        isGameOver = true; //bikin game over biar game ngulang
        Time.timeScale = 1f;  //set skala waktu jadi 1 biar lanjut 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit(); //kluar dari unity
    }
}
