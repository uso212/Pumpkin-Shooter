using System.Collections;
using Gameplay;
using UnityEngine;

/// <summary>
/// We spawn the enemies and manage the behaviour when they are hit.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private GameObject _pumpkin;
    private Rigidbody _pumpkinRigidBody;

    private ObjectPoolManager _poolManager;

    private void Awake() => _poolManager = GetComponent<ObjectPoolManager>();

    private void Start() => SpawnEnemy();

    /// <summary>
    /// We start bringing enemies (pumpkins) from the pool and set its position.
    /// </summary>
    private void SpawnEnemy()
    {
        _pumpkin = _poolManager.GetPooledObject();
        _pumpkin.SetActive(true);
        _pumpkin.transform.position = _spawnPoint.position;
        _pumpkin.transform.rotation = _spawnPoint.rotation;
        _pumpkinRigidBody = _pumpkin.GetComponent<Rigidbody>();
        _pumpkinRigidBody.velocity = Vector3.zero;
        _pumpkinRigidBody.angularVelocity = Vector3.zero;
    }

    /// <summary>
    /// If the pumpkin gets hit, we add a force to the pumpkin.
    /// </summary>
    /// <param name="collision">The object it collided with</param>
    public void PumpkinShot(Collision collision)
    {
        collision.gameObject.SetActive(false);
        _pumpkinRigidBody.AddForceAtPosition(collision.transform.forward, collision.GetContact(0).point, ForceMode.Impulse);
        Die();
    }

    /// <summary>
    /// Starts the process of deactivating the enemy from the scene.
    /// </summary>
    private void Die()
    {
        ScoreManager.Instance.AddScore(_pumpkin.GetComponent<Enemy>().scoreValue);
        _pumpkinRigidBody.useGravity = true;
        StartCoroutine(SendBackToPool());
    }

    /// <summary>
    /// It sends back to the pool the attacked pumpkin.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SendBackToPool()
    {
        yield return new WaitForSeconds(0.5f);
        _pumpkin.SetActive(false);
        yield return new WaitForSeconds(2f);
        SpawnEnemy();
    }
}
