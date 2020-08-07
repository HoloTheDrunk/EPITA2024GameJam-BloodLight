using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class SpikeScript : MonoBehaviour
    {
        public Vector2 spawnPoint;
        private GameObject _player;
        private SpriteRenderer _playerSpriteRenderer;
        private PlayerController _playerController;
        private Rigidbody2D _playerRb;

        void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _playerSpriteRenderer = _player.GetComponent<SpriteRenderer>();
            _playerController = _player.GetComponent<PlayerController>();
            _playerRb = _player.GetComponent<Rigidbody2D>();
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
                
                Invoke("RespawnPlayer", .5f);
            }
        }

        public void RespawnPlayer()
        {
            _player.transform.position = new Vector2(0f, 0.96f);
            _playerSpriteRenderer.enabled = true;
            _playerController.enabled = true;
            _playerRb.isKinematic = false;
        }
    }
}
