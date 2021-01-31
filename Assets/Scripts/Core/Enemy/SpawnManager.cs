using System.Collections;
using UnityEngine;

namespace Core.Enemy
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefeb;
        [SerializeField] private GameObject _enemyContainer;
        [SerializeField] private int _maxNum = 5;

        private int _curNum;
        private bool _stopSpawning;

        private void Start()
        {
            _curNum = 0;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (!_stopSpawning)
            {
                if (_enemyPrefeb != null && _curNum < _maxNum)
                {
                    var enemy = Instantiate(_enemyPrefeb, _enemyContainer.transform, false);
                    enemy.GetComponent<Enemy>()?.ReSpawn();
                    _curNum++;
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
