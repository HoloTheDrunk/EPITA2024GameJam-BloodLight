using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class KillAreaScript : MonoBehaviour
    {
        private GameObject _player;
        private SpriteRenderer _playerSpriteRenderer;
        private PlayerController _playerController;
        private Rigidbody2D _playerRb;

        public void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _playerSpriteRenderer = _player.GetComponent<SpriteRenderer>();
            _playerController = _player.GetComponent<PlayerController>();
            _playerRb = _player.GetComponent<Rigidbody2D>();
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            switch(other.gameObject.tag)
            {
                case "Player":
                    other.rigidbody.velocity = Vector2.zero;
                    _playerSpriteRenderer.enabled = false;
                    _playerController.enabled = false;
                    _playerRb.isKinematic = true;

                    RespawnPlayer();
                    break;
                
                case "Particle":
                    Destroy(other.gameObject);
                    break;
            }
        }
        
        // Repeated this code that was already in SpikeScript.cs because I have no idea how to invoke from another
        // script.
        public void RespawnPlayer()
        {
            _player.transform.position = new Vector2(0f, 0.96f);
            _playerSpriteRenderer.enabled = true;
            _playerController.enabled = true;
            _playerRb.isKinematic = false;
        }


        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}
