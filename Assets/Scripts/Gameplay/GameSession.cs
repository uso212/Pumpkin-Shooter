using UnityEngine;

/// <summary>
/// Manages the game state.
/// </summary>
public class GameSession : MonoBehaviour
{
    public System.Action OnSessionStart;
    public System.Action OnSessionEnd;

    public float timeLeft;

    private enum SessionState
    {
        Paused,
        Active,
        Finished
    }

    private SessionState _state = SessionState.Paused;

    private void Start() => StartSession();

    /// <summary>
    /// We manage the countdown in this Update function.
    /// </summary>
    private void Update()
    {
        if (_state != SessionState.Active) return;
        
        timeLeft -= Time.deltaTime;

        if (!(timeLeft <= 0)) return;
        timeLeft = 0;
        EndSession();
    }
    
    /// <summary>
    /// When we start the game
    /// </summary>
    private void StartSession()
    {
        _state = SessionState.Active;
        
        OnSessionStart?.Invoke();
    }

    /// <summary>
    /// When we finished the game.
    /// </summary>
    private void EndSession() => OnSessionEnd?.Invoke();
}
