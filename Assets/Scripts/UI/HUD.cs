using Data;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// It handles the information displayed in the HUD during the game session.
/// </summary>
public class HUD : MonoBehaviour {
    [Header("Game Session Info")]
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private Text _scoreValue;
    [SerializeField] private GameObject _timeRemaining;
    [SerializeField] private Text _timeRemainingValue;
    [SerializeField] private GameObject _playerName;
    [Header("Game Over")]
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _gameOverScreenLabel;

    private SetPlayerData _setPlayerData;
    private int _newHighScore;

    private void Awake() => _setPlayerData = GetComponent<SetPlayerData>();

    private void Start() => _gameSession.OnSessionEnd += HandleSessionEnded;

    /// <summary>
    /// If formats the time to be displayed in the UI HUD
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    private static string GetFormattedTimeFromSeconds( float seconds ) => 
        Mathf.FloorToInt( seconds / 60.0f ).ToString("0") + ":" + 
        Mathf.FloorToInt( seconds % 60.0f ).ToString("00");

    /// <summary>
    /// Handles the end of the game.
    /// </summary>
    private void HandleSessionEnded()
    {
        _gameSession.OnSessionEnd -= HandleSessionEnded;
        _timeRemaining.SetActive(false);
        _gameOverScreen.SetActive(true);
        _gameOverScreenLabel.SetActive(true);
        NewHighScoreCheck();
    }
    
    private void Update() => _timeRemainingValue.text = GetFormattedTimeFromSeconds(_gameSession.timeLeft);

    /// <summary>
    /// If the current score is greater than the actual high score, we activate the field to input your name.
    /// </summary>
    private void NewHighScoreCheck()
    {
        if (!int.TryParse(_scoreValue.text, out var currentScore)) return;

        if (currentScore <= DataToUpload.Instance.GetData().HighScore) return;

        _newHighScore = currentScore;
        
        _playerName.SetActive(true);
    }

    /// <summary>
    /// Here we set the new high score if it's greater than the previous one
    /// </summary>
    public void SetNewHighScore()
    {
        if (_newHighScore <= DataToUpload.Instance.GetData().HighScore) return;
        
        _setPlayerData.SetResultData(_newHighScore, _playerName.GetComponent<InputField>().text);
    }
}
