using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Maintains the game object alive even if we change scenes. 
    /// </summary>
    public class DontDestroy: MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(this);
    }
}