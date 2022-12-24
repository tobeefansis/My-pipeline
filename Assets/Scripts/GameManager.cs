using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
   

    [SerializeField] private GameState gameState;
    [SerializeField] private UnityEvent onBuildingState;
    [SerializeField] private UnityEvent onPlayingState;

    public GameState GameState
    {
        get => gameState;
        set => gameState = value;
    }
    public void SetBuildingState()
    {
        gameState = GameState.Building;
        onBuildingState.Invoke();
    }
    public void SetPlayingState()
    {
        gameState = GameState.Playing;
        onPlayingState.Invoke();
    }
}
public enum GameState
{
    Building,
    Playing
}