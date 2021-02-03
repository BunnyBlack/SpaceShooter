using System.Collections;
using UnityEngine;

namespace Core.Enemy
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefeb;
        [SerializeField] private GameObject _enemyContainer;
        private bool _isEnemyPrefebNotNull;

        private bool _stopSpawning;

        private void Start()
        {
            _isEnemyPrefebNotNull = _enemyPrefeb != null;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (!_stopSpawning)
            {
                if (_isEnemyPrefebNotNull)
                {
                    var enemy = Instantiate(_enemyPrefeb, _enemyContainer.transform, false);
                    enemy.GetComponent<Enemy>()?.ReSpawn();
                }
                yield return new WaitForSeconds(5);
            }
        }

        public void OnPlayerDeath()
        {
            _stopSpawning = true;
            Debug.Log("Oops, I'm defeated.");
        }
    }
}
