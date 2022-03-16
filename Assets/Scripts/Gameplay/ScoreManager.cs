using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    /// <summary>
    /// Class in charge of managing the score of the player.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        
        [SerializeField] private Text _scoreText;

        private int _currentScore;

        private void Awake()
        {
            Instance = this;
            _scoreText.text = "0";
        }

        /// <summary>
        /// We add the score corresponding to the enemy we hit, and show it
        /// in the UI.
        /// </summary>
        /// <param name="score"></param>
        public void AddScore(int score)
        {
            _currentScore += score;
            _scoreText.text = _currentScore.ToString();
        }
    }
}