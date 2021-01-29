﻿using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private float _speed = 4f;

        private const float BottomBoarder = -5.5f;
        private const float TopBoarder = 7f;
        private const float LeftBoarder = -9f;
        private const float RightBoarder = 9f;

        private void Update()
        {
            MoveDown();

            if (gameObject.transform.position.y < BottomBoarder)
            {
                ReSpawn();
            }
        }

        private void ReSpawn()
        {
            var respawnPositionX = Random.Range(LeftBoarder, RightBoarder);
            var curPosition = gameObject.transform.position;
            gameObject.transform.position = new Vector3(respawnPositionX, TopBoarder, curPosition.z);
        }

        private void MoveDown()
        {
            gameObject.transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "Player":
                    Debug.Log("Damage the player");
                    Destroy(gameObject);
                    break;
                case "Laser":
                    Debug.Log("Hit by laser");
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
