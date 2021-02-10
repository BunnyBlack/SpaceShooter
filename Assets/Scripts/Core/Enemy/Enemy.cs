using UnityEngine;

namespace Core.Enemy
{
    public class Enemy : MonoBehaviour
    {

        private const float BottomBoarder = -5.5f;
        private const float TopBoarder = 7f;
        private const float LeftBoarder = -9f;
        private const float RightBoarder = 9f;
        private static readonly int OnEnemyDeath = Animator.StringToHash("OnEnemyDeath");
        [SerializeField] private float _speed = 4f;
        [SerializeField] private AudioClip _explosionAudioClip;
        private Animator _animator;
        private AudioSource _audioSource;
        private Player.Player _player;

        private void Start()
        {
            _player = GameObject.Find("/Player")?.GetComponent<Player.Player>();
            _animator = gameObject.GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
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

                    OnDestroySelf();

                    Destroy(gameObject, 2.8f);
                    break;
                case "Laser":
                    Destroy(other.gameObject);
                    _player.AddScore();

                    OnDestroySelf();

                    Destroy(gameObject, 2.8f);
                    break;
            }
        }

        private void OnDestroySelf()
        {

            _animator.SetTrigger(OnEnemyDeath);
            _speed = 0;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _audioSource.PlayOneShot(_explosionAudioClip);
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
