using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpikeScript : MonoBehaviour
    {
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject particle = (GameObject) Instantiate(Resources.Load("Prefabs/DeathParticle"));
                    particle.transform.position = other.transform.position;
                }
                other.transform.position = new Vector2(0f, 0.32f);
                other.rigidbody.velocity = Vector2.zero;
            }
        }
    }
}
