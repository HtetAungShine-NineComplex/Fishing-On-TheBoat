using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonNonPersistance<GameManager>
{
    [SerializeField] private float _gameDurationInMinute;
    [SerializeField] private Timer _levelTimer;
    [SerializeField] private GameObject _gameOverPanel;

    public bool _isGameOver = false;

    private int _score;
    

    private void Start()
    {
        _levelTimer.Initialize(_gameDurationInMinute);

        _levelTimer.StartTimer();

        GLOBALEVENTS.TimesUp += GameOver;
    }

    private void OnDestroy()
    {
        GLOBALEVENTS.TimesUp -= GameOver;
    }

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;

            GLOBALEVENTS.InvokeScoreChanged(_score);
        }
    }

    private void GameOver()
    {
        _isGameOver = true;
        _gameOverPanel.SetActive(true);
    }

    public void Restart() 
    {
        _isGameOver = false;
        _score = 0;
        _gameOverPanel.SetActive(false);
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
