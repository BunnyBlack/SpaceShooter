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

        public void StartSpawning()
        {
            _isEnemyPrefebNotNull = _enemyPrefeb != null;
            StartCoroutine(SpawnEnemyRoutine());
            StartCoroutine(SpawnPowerUpTripleShotRoutine());
        }

        private IEnumerator SpawnEnemyRoutine()
        {
            yield return new WaitForSeconds(3f);

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

        private IEnumerator SpawnPowerUpTripleShotRoutine()
        {
            yield return new WaitForSeconds(3f);

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
        }
    }
}
