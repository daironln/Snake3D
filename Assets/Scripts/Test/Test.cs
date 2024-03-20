#if UNITY_EDITOR
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class Test
{
    static Test()
    {
        EditorApplication.playModeStateChanged += HandlePlayModeState;
    }

    private static void OnDisable()
    {
        EditorApplication.playModeStateChanged -= HandlePlayModeState;
    }

    private static void HandlePlayModeState(PlayModeStateChange state)
    {
        if (state != PlayModeStateChange.EnteredPlayMode) return;
        GameManager.Instance.gameState = GameState.InGame;
        Debug.Log("Ejecutando codigo de test in Play Mode!");
    }
}
#endif