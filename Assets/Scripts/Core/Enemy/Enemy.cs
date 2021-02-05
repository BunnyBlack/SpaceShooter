using UnityEngine;

namespace Core.Enemy
{
    public class Enemy : MonoBehaviour
    {

        private const float BottomBoarder = -5.5f;
        private const float TopBoarder = 7f;
        private const float LeftBoarder = -9f;
        private const float RightBoarder = 9f;
        [SerializeField] private float _speed = 4f;
        private Player.Player _player;

        private void Start()
        {
            _player = GameObject.Find("/Player")?.GetComponent<Player.Player>();
        }

        private void Update()
        {
            MoveDown();

            if (gameObject.transform.position.y < BottomBoarder)
                ReSpawn();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.tag)
            {
                case "Player":
                    other.gameObject.GetComponent<Player.Player>()?.Damaged();
                    Destroy(gameObject);
                    break;
                case "Laser":
                    Destroy(other.gameObject);
                    _player.AddScore();
                    Destroy(gameObject);
                    break;
            }
        }

        public void ReSpawn()
        {
            var respawnPositionX = Random.Range(LeftBoarder, RightBoarder);
            var curPosition = gameObject.transform.position;
            gameObject.transform.position = new Vector3(respawnPositionX, TopBoarder, curPosition.z);
        }

        private void MoveDown()
        {
            gameObject.transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        }
    }
}
