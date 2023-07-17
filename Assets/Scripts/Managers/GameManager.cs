using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private GameObject _clickZone;
    public void GameOver()
    {
        Progress.Instance.Save();
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
        _score.SetActive(false);
        _pausePanel.SetActive(false);
        _scoreManager.enabled = false;
        _clickZone.SetActive(false);
    }

    public void StartGame()
    {
        Progress.Instance.Load();
        Time.timeScale = 1;
        _mainMenuPanel.SetActive(false);
        _score.SetActive(true);
        _pausePanel.SetActive(true);
        _clickZone.SetActive(true);
    }
}
