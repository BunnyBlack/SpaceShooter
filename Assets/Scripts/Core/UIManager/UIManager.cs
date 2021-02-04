using UnityEngine;
using UnityEngine.UI;

namespace Core.UIManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        private void Start()
        {
            _scoreText.text = "Score: 0";
        }

        public void UpdateScore(int score)
        {
            _scoreText.text = $"Score: {score.ToString()}";
        }
    }
}
