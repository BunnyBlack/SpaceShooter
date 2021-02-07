using UnityEngine;

namespace Core.Enemy
{
    public class Astroid : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed = 19.0f;

        private void Update()
        {
            gameObject.transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
        }
    }
}
