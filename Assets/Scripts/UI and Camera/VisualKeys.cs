using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.UI_and_Camera
{
	public class VisualKeys : MonoBehaviour
	{
		[SerializeField] [Range(0f, 1f)] private float _offset = .8f;

		private Vector3 _originalScale;

		[SerializeField] private GameObject _left = null;
		[SerializeField] private GameObject _right = null;
		[SerializeField] private GameObject _space = null;

		[SerializeField] private InputHandler _inputHandler = null;

		public void Start()
		{
			_originalScale = Vector3.one * _space.transform.localScale.x;
		}

		// Update is called once per frame
		public void Update()
		{
			// Left
			if (_inputHandler.x < -0.2)
			{
				_left.transform.localScale = _originalScale * _offset;
			}
			else
			{
				_left.transform.localScale = _originalScale;

				if (_inputHandler.x > 0.2)
					_right.transform.localScale = _originalScale * _offset;
				else
					_right.transform.localScale = _originalScale;
			}

			if (Input.GetAxis("Jump") > 0.1)
				_space.transform.localScale = _originalScale * _offset;
			else
				_space.transform.localScale = _originalScale;
		}
	}
}