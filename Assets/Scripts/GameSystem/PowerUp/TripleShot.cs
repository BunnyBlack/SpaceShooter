using Core.Player;
using UnityEngine;

namespace GameSystem.PowerUp
{
    public class TripleShot : MonoBehaviour
    {
        private const float BottomBoarder = -5.5f;
        private const float TopBoarder = 7f;
        private const float LeftBoarder = -9f;
        private const float RightBoarder = 9f;
        [SerializeField] private float _speed = 3f;

        private void Update()
        {
            MoveDown();

            if (gameObject.transform.position.y < BottomBoarder)
                ReSpawn();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            other.gameObject.GetComponent<Player>()?.TripleShotActive();
            Destroy(gameObject);
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
