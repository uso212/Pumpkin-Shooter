using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    /// <summary>
    /// Class in charge of switching scenes.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        public enum SceneToLoad
        {
            MainMenu,
            GameScene
        }

        public SceneToLoad sceneToLoad;
        public void LoadScene() => SceneManager.LoadScene((int)sceneToLoad);
    }
}