using UnityEngine;

namespace Assets.Scripts
{
    public class FinishScript : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Finished");
            }
        }
    }
}
