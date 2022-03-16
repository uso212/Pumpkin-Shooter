using UnityEngine;

/// <summary>
/// Controls the enemy (pumpkin) movement. 
/// </summary>
public class Enemy : MonoBehaviour
{
    [Header("Score")]
    public int scoreValue = 100;

    [Header("Movement")]
    [SerializeField] private float _verticalAmplitude = 2.5f;
    [SerializeField] private float _verticalFrequency = 2.5f;

    private Vector3 _startPosition = Vector3.zero;

    private void Start() => _startPosition = transform.position;

    private void Update()
    {
        var positionOffset = Mathf.Sin( Time.timeSinceLevelLoad / _verticalFrequency ) * _verticalAmplitude;
        transform.position = new Vector3( _startPosition.x, _startPosition.y + positionOffset, _startPosition.z );
    }
}
