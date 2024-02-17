using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // globally accessed class to manage game state
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> onGameStateChanged;
    private AudioSystem audioSystem;
    // keep track of day
    public static int currentDay = 50;
    void Awake() {
        currentDay = 0;
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        audioSystem = GetComponent<AudioSystem>();
    }

    void Start() {
        UpdateGameState(GameState.MenuSelect);
    }

    public void UpdateGameState(GameState newState) {
        state = newState;
        // handles state specific logic
        switch(newState) {
            case GameState.MenuSelect:
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        onGameStateChanged?.Invoke(newState);
    }

    public void playAudio() {
        Debug.Log(audioSystem.ReturnAudio());
    }
}

public enum GameState {
    MenuSelect,
    Playing,
    GameOver
}
