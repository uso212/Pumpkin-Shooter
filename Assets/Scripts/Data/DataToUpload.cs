using System.IO;
using UnityEngine;

namespace Data
{
    /// <summary>
    /// Here we create the file, get and set the data into a serialized format (Json).
    /// </summary>
    public class DataToUpload : MonoBehaviour
    {
        public static DataToUpload Instance;
        
        private string _userDataFile;
            
        private void Awake()
        {
            Instance = this;
            
            _userDataFile = $"{Application.persistentDataPath}/userdata.json";
        }

        /// <summary>
        /// After we finished the game we set the results into the file.
        /// </summary>
        /// <param name="resultData">Data to be saved into Json format</param>
        public void SetData(ResultData resultData)
        {
            var data = JsonUtility.ToJson(resultData);
            
            File.WriteAllText(_userDataFile, data);
        }

        /// <summary>
        /// Get the Data we have into the file, if the file does not exist, we send
        /// default data.
        /// </summary>
        /// <returns>The data saved into the file or default values.</returns>
        public ResultData GetData()
        {
            var data = "";
            
            if (File.Exists(_userDataFile))
            {
                data = File.ReadAllText(_userDataFile);
            }

            ResultData userData;

            if (string.IsNullOrEmpty(data))
            {
                userData = new ResultData()
                {
                    HighScore = 0,
                    PlayerName = "None"
                };
            }
            else
            {
                userData = JsonUtility.FromJson<ResultData>(data);
            }

            return userData;
        }
    }
}
