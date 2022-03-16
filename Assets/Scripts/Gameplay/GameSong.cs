using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// It plays the game main song in a loop.
    /// </summary>
    public class GameSong: MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;

        private AudioSource _source;

        private void Awake() => _source = GetComponent<AudioSource>();

        private void Start() => StartPlayingSong();

        private void StartPlayingSong()
        {
            _source.clip = _clip;
            _source.Play();
        }
    }
}