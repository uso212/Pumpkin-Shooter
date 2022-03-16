using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Object pool that instantiates a certain amount of GameObjects at the beginning of the game
    /// to save resources on the long run. It manages the returning of said game objects.
    /// </summary>
    public class ObjectPoolManager : MonoBehaviour
    {
        [HideInInspector] public List<GameObject> pooledObjects = new List<GameObject>();

        public GameObject[] objectToPool;

        [SerializeField] private int amountToPool;

        private void Awake() => GeneratePool();

        /// <summary>
        /// We instantiate randomly the game objects in the pool.
        /// </summary>
        /// <returns></returns>
        private GameObject GetRandomObject() => objectToPool[Random.Range(0, objectToPool.Length)];

        /// <summary>
        /// We generate a pool of game objects to be used by all the character in-game.
        /// </summary>
        private void GeneratePool()
        {
            for (var i = 0; i < amountToPool; i++)
            {
                var item = Instantiate(GetRandomObject());
                item.SetActive(false);
                pooledObjects.Add(item);
            }
        }

        /// <summary>
        /// We look for an available game object in the pool and return it to the player to be used.
        /// We get a random available game object in the pool.
        /// </summary>
        /// <returns></returns>
        public GameObject GetPooledObject()
        {
            for (var i = 0; i < pooledObjects.Count; i++)
            {
                var randomPooledObject = Random.Range(0, pooledObjects.Count);
                if (!pooledObjects[randomPooledObject].activeInHierarchy)
                {
                    return pooledObjects[randomPooledObject];
                }
            }

            return null;
        }
    }
}