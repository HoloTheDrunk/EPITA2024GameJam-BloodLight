using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI_and_Camera.Menus
{
    public class ToggleScript : MonoBehaviour
    {
        [SerializeField] private bool _state = false;
        public Image _image;
        public Sprite off;
        public Sprite on;

        public bool State => _state;

        public void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Toggle()
        {
            if (_state)
                _image.sprite = off;
            else
                _image.sprite = on;

            _state = !_state;
        }
    }
}
