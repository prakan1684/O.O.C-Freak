using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;


    public static event Action<GameState> OnGameStateChanged;
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }
    // Start is called before the first frame update
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                HandleStartMenu();
                break;
            case GameState.CutScene:
                break;
            case GameState.Level1:
                HandleLevel1();
                break;
            case GameState.Level2:
                HandleLevel2();
                break;
            case GameState.Level3:
                break;
            case GameState.BossFight:
                break;
            case GameState.PauseMenu:
                HandlePauseMenu();
                break;
            case GameState.EndScene:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleLevel2()
    {
        SceneManager.LoadScene("Level2");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
    private void HandleLevel1()
    {
        Time.timeScale = 1f;
        //CountDownTimer.instance.timerHasStarted = true;
    }
    private void HandleStartMenu()
    {
        Time.timeScale = 0f;
        //CountDownTimer.instance.timerHasStarted = false;


    }
    private void HandlePauseMenu()
    {

    }
}

public enum GameState
{
    MainMenu,
    CutScene,
    Level1,
    Level2,
    Level3,
    BossFight,
    PauseMenu,
    EndScene
}