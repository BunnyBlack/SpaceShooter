using System.Collections;
using GameSystem.PowerUp;
using UnityEngine;

namespace Core.Enemy
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefeb;
        [SerializeField] private GameObject[] _powerUpPrefebs;
        [SerializeField] private GameObject _enemyContainer;
        [SerializeField] private GameObject _powerUpContainer;
        private bool _isEnemyPrefebNotNull;

        private bool _stopSpawning;

        private void Start()
        {
            _isEnemyPrefebNotNull = _enemyPrefeb != null;
            StartCoroutine(SpawnEnemy());
            StartCoroutine(SpawnPowerUpTripleShot());
        }

        private IEnumerator SpawnEnemy()
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

        private IEnumerator SpawnPowerUpTripleShot()
        {
            while (!_stopSpawning)
            {
                if (_isEnemyPrefebNotNull)
                {
                    var randomPowerUp = Random.Range(0, 3);
                    var powerUpTripleShot = Instantiate(_powerUpPrefebs[randomPowerUp], _powerUpContainer.transform, false);
                    powerUpTripleShot.GetComponent<PowerUp>()?.ReSpawn();
                }
                yield return new WaitForSeconds(7);
            }
        }

        public void OnPlayerDeath()
        {
            _stopSpawning = true;
            Debug.Log("Oops, I'm defeated.");
        }
    }
}
