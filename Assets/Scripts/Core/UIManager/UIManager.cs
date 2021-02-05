using UnityEngine;
using UnityEngine.UI;

namespace Core.UIManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Sprite[] _liveSprites;
        [SerializeField] private Image _liveImage;
        [SerializeField] private GameObject _gameOverObj;

        private void Start()
        {
            _liveImage.sprite = _liveSprites[3];
            _scoreText.text = "Score: 0";
            _gameOverObj.SetActive(false);
        }

        public void UpdateScore(int score)
        {
            _scoreText.text = $"Score: {score.ToString()}";
        }

        public void UpdateLiveImage(int currentLives)
        {
            _liveImage.sprite = _liveSprites[currentLives];
            if (currentLives < 1)
                _gameOverObj.SetActive(true);
        }
    }
}
