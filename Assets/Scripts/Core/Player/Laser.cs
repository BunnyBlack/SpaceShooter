using System;
using UnityEngine;

namespace Core.Player
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private float _speed = 8f;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private void Update()
        {
            Move();

            if (gameObject.transform.position.y > 8f)
            {
                Destroy(gameObject);
            }
        }

        private void Move()
        {
            gameObject.transform.Translate(Vector3.up * (_speed * Time.deltaTime));
        }
    }
}
