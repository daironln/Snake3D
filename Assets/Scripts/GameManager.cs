using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    InMainMenu,
    InGame,
    InPause,
    GameOver
}
public class GameManager : PersistentSingleton<GameManager>
{
    public GameState gameState;

    protected override void Awake()
    {
        base.Awake();
        gameState = GameState.InMainMenu;
    }
    
}
