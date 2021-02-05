using UnityEngine;
using UnityEngine.UI;

namespace Core.UIManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Sprite[] _liveSprites;
        [SerializeField]private Image _liveImage;

        private void Start()
        {
            _liveImage.sprite = _liveSprites[3];
            _scoreText.text = "Score: 0";
        }

        public void UpdateScore(int score)
        {
            _scoreText.text = $"Score: {score.ToString()}";
        }

        public void UpdateLiveImage(int currentLives)
        {
            _liveImage.sprite = _liveSprites[currentLives];
        }
    }
}
