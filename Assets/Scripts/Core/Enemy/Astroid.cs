using System;
using UnityEngine;

namespace Core.Enemy
{
    public class Astroid : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed = 19.0f;
        [SerializeField] private GameObject _explosionObj;
        
        private void Update()
        {
            gameObject.transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Laser"))
            {
                _rotateSpeed = 0;
                Instantiate(_explosionObj, gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(gameObject, 0.25f);
            }
        }
    }
}
