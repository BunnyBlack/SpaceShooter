using UnityEngine;

namespace Core.Enemy
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private AudioClip _explosionAudioClip;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.PlayOneShot(_explosionAudioClip);
            Destroy(gameObject, 3.0f);
        }
    }
}
