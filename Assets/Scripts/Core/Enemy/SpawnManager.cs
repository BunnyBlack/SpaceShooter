using System.Collections;
using UnityEngine;

namespace Core.Enemy
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefeb;
        [SerializeField] private int _maxNum = 5;

        private int _curNum;

        private void Start()
        {
            _curNum = 0;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(5);

                if (_enemyPrefeb == null || _curNum >= _maxNum)
                    continue;

                var enemy = Instantiate(_enemyPrefeb);
                enemy.GetComponent<Enemy>()?.ReSpawn();
                _curNum++;
            }
        }
    }
}
