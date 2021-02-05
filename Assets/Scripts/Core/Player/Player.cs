﻿using Core.Enemy;
using UnityEngine;

namespace Core.Player
{
    public class Player : MonoBehaviour
    {
        private const float TopBoarder = 0f;
        private const float BottomBoarder = -3.8f;
        private const float LeftBoarder = -11f;
        private const float RightBoarder = 11f;


        [SerializeField] private float _speed = 5f;
        [SerializeField] private GameObject _laserPrefeb;
        [SerializeField] private GameObject _tripleShotPrefeb;
        [SerializeField] private GameObject _shieldObj;
        [SerializeField] private float _coolDown = 0.15f;
        [SerializeField] private int _lives = 3;

        private float _canFire;

        private float _horizontalInput;
        private bool _isShieldOn;
        private bool _isSpeedUp;
        private bool _isTripleShotActive;
        private int _score;


        private SpawnManager _spawnManager;
        private UIManager.UIManager _uiManager;
        private float _verticalInput;


        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private void Start()
        {
            InitPosition();
            _spawnManager = GameObject.Find("/SpawnManager")?.GetComponent<SpawnManager>();
            _uiManager = GameObject.Find("/Canvas")?.GetComponent<UIManager.UIManager>();
            ShieldOn(false);
        }

        private void Update()
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
                Shoot();

        }

        public void Damaged()
        {
            if (_isShieldOn)
            {
                ShieldOn(false);
                Debug.Log("Shield Breaks");
                return;
            }

            _lives--;
            _uiManager.UpdateLiveImage(_lives);
            
            if (_lives >= 1)
                return;

            if (_spawnManager is null)
            {
                Debug.LogError("The spawn manager is null!");
            }
            else
            {
                _spawnManager.OnPlayerDeath();
                Destroy(gameObject);
            }
        }

        public void TripleShotActive()
        {
            _isTripleShotActive = true;
            Debug.Log("Power Up: Triple Shot");
            Invoke(nameof(PowerDown), 5.0f);
        }

        public void SpeedUpActive()
        {
            _isSpeedUp = true;
            _speed = 8.5f;
            Debug.Log("Power Up: Speed Up");
            Invoke(nameof(SpeedDown), 5.0f);
        }

        public void ShieldOn(bool isOn)
        {
            _isShieldOn = isOn;
            _shieldObj.SetActive(isOn);
        }

        public void AddScore()
        {
            _score += 10;
            _uiManager.UpdateScore(_score);
        }

        private void Shoot()
        {
            _canFire = Time.time + _coolDown;

            var curPosition = gameObject.transform.position;
            if (_isTripleShotActive)
            {
                Instantiate(_tripleShotPrefeb, curPosition, Quaternion.identity);
            }
            else
            {
                var laserInitPosition = new Vector3(curPosition.x, curPosition.y + 1.05f, curPosition.z);
                Instantiate(_laserPrefeb, laserInitPosition, Quaternion.identity);
            }
        }

        private void InitPosition()
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }

        private void Move()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
            var direction = new Vector3(_horizontalInput, _verticalInput, 0);
            gameObject.transform.Translate(direction * (Speed * Time.deltaTime));

            CheckBoarder();
        }

        private void CheckBoarder()
        {
            var curPosition = gameObject.transform.position;
            gameObject.transform.position = new Vector3(curPosition.x,
                Mathf.Clamp(curPosition.y, BottomBoarder, TopBoarder), 0);

            if (gameObject.transform.position.x < LeftBoarder)
                gameObject.transform.position = new Vector3(RightBoarder, curPosition.y, 0);
            else if (gameObject.transform.position.x > RightBoarder)
                gameObject.transform.position = new Vector3(LeftBoarder, curPosition.y, 0);
        }

        private void PowerDown()
        {
            _isTripleShotActive = false;
            Debug.Log("Power Down: Triple Shot");
        }

        private void SpeedDown()
        {
            _isSpeedUp = false;
            _speed = 5f;
            Debug.Log("Power Down: Speed up");
        }
    }

}
