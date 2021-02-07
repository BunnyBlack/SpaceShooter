using UnityEngine;

namespace Core.Enemy
{
    public class Explosion : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 3.0f);
        }
    }
}
