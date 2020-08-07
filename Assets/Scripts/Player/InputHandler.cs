using UnityEngine;

namespace Assets.Scripts.Player
{
	public class InputHandler : MonoBehaviour
	{
		[HideInInspector] public float x;

		[HideInInspector] public bool jump = false;
		private bool _canJump = true;

		[HideInInspector] public Vector2 mousePos;

		// Update is called once per frame
		void Update()
		{
			x = Input.GetAxis("Horizontal");
			jump = Input.GetAxis("Jump") > 0f && _canJump;

			if (jump)
			{
				_canJump = false;
				Invoke("ResetJump", .1f);
			}

			mousePos = Input.mousePosition;
		}

		void ResetJump()
		{
			_canJump = true;
		}
	}
}