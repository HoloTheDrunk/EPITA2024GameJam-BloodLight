using UnityEngine;

namespace Assets.Scripts.UI_and_Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _player = null;
        
        void LateUpdate()
        {
            transform.position = new Vector3(_player.position.x, _player.position.y, -1);
        }
    }
}
