﻿using UnityEngine;

namespace Core.Enemy
{
    public class Astroid : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed = 19.0f;
        [SerializeField] private GameObject _explosionObj;

        private SpawnManager _spawnManager;
        private UIManager.UIManager _uiManager;

        private void Start()
        {
            _spawnManager = GameObject.Find("/SpawnManager")?.GetComponent<SpawnManager>();
            _uiManager = GameObject.Find("/Canvas")?.GetComponent<UIManager.UIManager>();
        }

        private void Update()
        {
            gameObject.transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Laser"))
                return;

            _rotateSpeed = 0;
            Instantiate(_explosionObj, gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _spawnManager.StartSpawning();
            _uiManager.ShowHub();
            Destroy(gameObject, 0.25f);
        }
    }
}
