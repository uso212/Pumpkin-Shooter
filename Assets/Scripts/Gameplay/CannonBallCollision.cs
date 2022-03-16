using System.Collections;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Class in charge of checking if the pumpkin collided with a cannon ball. 
    /// </summary>
    public class CannonBallCollision : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;
        
        private CapsuleCollider _capsuleCollider;

        private void Awake() => _capsuleCollider = GetComponent<CapsuleCollider>();

        /// <summary>
        /// This detects if a pumpkin collided with a cannon ball.
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter( Collision collision )
        {
            /*
             * Switched to CompareTag since it's faster than having a script with empty methods, and it's
             * 5x faster than the C# .Equals() method.
             */

            if (!collision.gameObject.CompareTag("CannonBall")) return;
        
            enemySpawner.PumpkinShot(collision);

            StartCoroutine(ToggleCollider());
        }

        /// <summary>
        /// We deactivate the collider until another pumpkin is brought from the pool.
        /// </summary>
        /// <returns></returns>
        private IEnumerator ToggleCollider()
        {
            _capsuleCollider.enabled = false;
            yield return new WaitForSeconds(2.5f);
            _capsuleCollider.enabled = true;
        }
        
    }
}