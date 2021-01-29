using UnityEngine;


namespace Core.Player
{
    public class Player : MonoBehaviour
    {
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }


        [SerializeField] private float _speed = 5f;
        [SerializeField] private GameObject _laserPrefeb;
        [SerializeField] private float _coolDown = 0.15f;
        [SerializeField] private int _lives = 3;
        private float _canFire;

        private float _horizontalInput;
        private float _verticalInput;
        private const float TopBoarder = 0f;
        private const float BottomBoarder = -3.8f;
        private const float LeftBoarder = -11f;
        private const float RightBoarder = 11f;

        private void Start()
        {
            InitPosition();
        }

        private void Update()
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
            {
                Shoot();
            }

        }

        public void Damaged()
        {
            _lives--;

            Debug.Log($"Live:{_lives}");
            if (_lives >= 1)
                return;

            Debug.Log("Oops, I'm defeated");
            Destroy(gameObject);
        }

        private void Shoot()
        {
            _canFire = Time.time + _coolDown;

            var curPosition = gameObject.transform.position;
            var laserInitPosition = new Vector3(curPosition.x, curPosition.y + 0.8f, curPosition.z);
            Instantiate(_laserPrefeb, laserInitPosition, Quaternion.identity);
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
            {
                gameObject.transform.position = new Vector3(RightBoarder, curPosition.y, 0);
            }
            else if (gameObject.transform.position.x > RightBoarder)
            {
                gameObject.transform.position = new Vector3(LeftBoarder, curPosition.y, 0);
            }
        }
    }

}
