using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Core.Player
{
    public class Player : MonoBehaviour
    {
        public float Speed { get; set; } = 3.5f;

        private float _horizontalInput;
        private float _verticalInput;

        private void Start()
        {
            InitPosition();
        }

        private void Update()
        {
            Move();
        }

        private void InitPosition()
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }

        private void Move()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
            var direction = new Vector3(_horizontalInput, 0, _verticalInput);
            gameObject.transform.Translate(direction * (Speed * Time.deltaTime));
        }
    }

}
