using Data;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the main menu UIs
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _highScore;
    [SerializeField] private Text _playerName;

    private ResultData _playerData;

    private void Awake() => _playerData = DataToUpload.Instance.GetData();

    /// <summary>
    /// We show the current high score and who achieved it.
    /// </summary>
    private void Start()
    {
        _highScore.text = _playerData.HighScore.ToString();
        _playerName.text = $"Best Player is: {_playerData.PlayerName}";
    }
}
