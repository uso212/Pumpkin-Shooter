using UnityEngine;

namespace Data
{
    /// <summary>
    /// It saves the data into the file after we finished the game session. 
    /// </summary>
    public class SetPlayerData : MonoBehaviour
    {
        private DataToUpload _dataToUpload;
        
        private void Awake() => _dataToUpload = DataToUpload.Instance;

        /// <summary>
        /// We set the data into the Json file.
        /// </summary>
        /// <param name="score">The new high score</param>
        /// <param name="playerName">Player name</param>
        public void SetResultData(int score, string playerName)
        {
            _dataToUpload.SetData(new ResultData
            {
                HighScore = score,
                PlayerName = playerName
            });
        }
    }
}