using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts
{
    public class CheckpointScript : MonoBehaviour
    {
        private PlayerController _playerController;
        [SerializeField] private AudioSource _audioSource;
        
        public void Start()
        {
            _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (_playerController.spawnPoint != transform)
                {
                    _playerController.spawnPoint = transform;
                    _audioSource.Play();
                }
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}
