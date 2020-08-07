using UnityEngine;

namespace Assets.Scripts
{
    public class DeathParticleScript : MonoBehaviour
    {
        private Rigidbody2D _rb;

        public void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)).normalized * 200);
            transform.GetChild(0).gameObject.SetActive(false);
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 8 || other.gameObject.layer == 10)
            {
                Destroy(_rb);
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
