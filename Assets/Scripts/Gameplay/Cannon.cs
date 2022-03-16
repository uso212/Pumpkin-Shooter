using System.Collections;
using Gameplay;
using UnityEngine;

/// <summary>
/// Class in charge of the cannon functionality.
/// </summary>
public class Cannon : MonoBehaviour
{
    [Header("Cannon Motion")]
    [SerializeField] private Transform _cannonTransform = null;
    [SerializeField] private Transform _cannonballSpawnPoint = null;
    [SerializeField] private float _rotationRate = 45.0f;
    [Header("Cannon Firing")]
    [SerializeField] private float _cannonballFireVelocity = 50.0f;
    [SerializeField] private float _rateOfFire = 0.33f;

    private float _timeOfLastFire;

    private ObjectPoolManager _poolManager;

    private void Awake() => _poolManager = GetComponent<ObjectPoolManager>();

    /// <summary>
    /// We subscribe to the OnSessionEnd event.
    /// </summary>
    private void Start() => FindObjectOfType<GameSession>().OnSessionEnd += () => enabled = false;
    
    /// <summary>
    /// We check for the input of the player
    /// </summary>
    private void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            FireCannon();
        }

        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            RotateCannon(-1);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateCannon(1);
        }
    }

    /// <summary>
    /// Rotates the cannon on the direction set by the Left and Right Arrow keys.
    /// </summary>
    /// <param name="direction">-1 for Left, 1 for Right movement</param>
    private void RotateCannon(int direction) 
    {
        _cannonTransform.Rotate( 0.0f, Time.deltaTime * _rotationRate * direction, 
            0.0f, Space.World );
    }

    /// <summary>
    /// When firing the cannon we bring a cannon ball from the pool 
    /// </summary>
    private void FireCannon()
    {
        if( Time.timeSinceLevelLoad > _timeOfLastFire + _rateOfFire )
        {
            var spawnedBall = _poolManager.GetPooledObject();
            spawnedBall.SetActive(true);
            spawnedBall.transform.position = _cannonballSpawnPoint.transform.position;
            spawnedBall.transform.rotation = _cannonTransform.rotation;
            var spawnedBallRigidBody = spawnedBall.GetComponent<Rigidbody>();
            spawnedBallRigidBody.velocity = Vector3.zero;
            spawnedBallRigidBody.angularVelocity = Vector3.zero;

            spawnedBall.GetComponent<Rigidbody>().AddForce( _cannonTransform.forward * _cannonballFireVelocity, ForceMode.Impulse );
            _timeOfLastFire = Time.timeSinceLevelLoad;
            
            StartCoroutine(DeactivateCannonBall(spawnedBall));
        }
    }

    /// <summary>
    /// If the cannon ball did not hit a pumpkin then we deactivate it after a while
    /// </summary>
    /// <param name="cannonBall">Cannon ball to deactivate</param>
    /// <returns></returns>
    private static IEnumerator DeactivateCannonBall(GameObject cannonBall)
    {
        yield return new WaitForSeconds(2.5f);
        
        if (cannonBall.activeSelf)
            cannonBall.SetActive(false);
    }
}
