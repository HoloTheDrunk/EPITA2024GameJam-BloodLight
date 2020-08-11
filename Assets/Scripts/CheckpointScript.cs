using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts
{
    public class CheckpointScript : MonoBehaviour
    {
        private PlayerController _playerController;
        [SerializeField] private AudioSource _audioSource = null;

        private GameObject _particleEmitter;
        private ParticleSystem _particleSystem;
        
        public void Start()
        {
            _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            _particleEmitter = transform.GetChild(0).gameObject;
            _particleSystem = _particleEmitter.GetComponent<ParticleSystem>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (_playerController.spawnPoint != transform)
                {
                    _playerController.spawnPoint = transform;
                    _audioSource.Play();
                    _particleEmitter.SetActive(true);
                    Invoke("ResetParticleSystem", _particleSystem.main.duration + _particleSystem.main.startLifetime.constant);
                }
            }
        }

        private void ResetParticleSystem() => _particleEmitter.SetActive(false);

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}
