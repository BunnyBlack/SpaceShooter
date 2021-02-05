using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.UIManager
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene("Scenes/Game");
        }
    }
}
