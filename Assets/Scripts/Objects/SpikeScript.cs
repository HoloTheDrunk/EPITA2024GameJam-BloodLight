using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class SpikeScript : MonoBehaviour
    {
        private GameObject _player;
        private SpriteRenderer _playerSpriteRenderer;
        private PlayerController _playerController;
        private Rigidbody2D _playerRb;
        private PlayerStats _playerStats;

        public void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _playerSpriteRenderer = _player.GetComponent<SpriteRenderer>();
            _playerController = _player.GetComponent<PlayerController>();
            _playerRb = _player.GetComponent<Rigidbody2D>();
            _playerStats = _player.GetComponent<PlayerStats>();
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject particle = (GameObject) Instantiate(Resources.Load("Prefabs/DeathParticle"));
                    particle.transform.position = other.transform.position;
                }
                other.rigidbody.velocity = Vector2.zero;
                _playerSpriteRenderer.enabled = false;
                _playerController.enabled = false;
                _playerRb.isKinematic = true;
                _playerStats.AddDeath();
                _playerController.sfxPlayer.PlayDeathSound();

                Invoke("RespawnPlayer", .5f);
            }
        }

        public void RespawnPlayer()
        {
            _player.transform.position = _playerController.spawnPoint.position;
            _playerSpriteRenderer.enabled = true;
            _playerController.enabled = true;
            _playerRb.isKinematic = false;
        }
    }
}
