using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerController : MonoBehaviour
	{
		// Player sprite
		private Sprite _playerSprite;

		// Input
		[HideInInspector] public InputHandler inputHandler;

		// Physics related
		[HideInInspector] public Rigidbody2D rb;
		[HideInInspector] public BoxCollider2D boxCollider2D;

		// Ground related
		[HideInInspector] public bool isGrounded;
		[HideInInspector] public bool canJump;
		[SerializeField] [Range(0, .32f)] private float _groundSensorWidth = 0;

		#region Constants

		// Ground layer
		public LayerMask groundLayer;

		// Horizontal constants
		public float maxMoveSpeed = 20f;
		public float moveSpeed = 20f;
		[Range(0f, 1f)] public float frictionCoefficient = .5f;
		[Range(1f, 10f)] public float frictionMultiplier = 5f;

		// Vertical constants
		public float terminalVelocity = 50f;
		public float jumpForce = 10f;
		[Range(0f, 100f)] public float jumpDampener = 65f;
		public float ExtraHeight = .01f;

		#endregion

		// Start is called before the first frame update
		public void Start()
		{
			_playerSprite = GetComponent<SpriteRenderer>().sprite;

			// ReSharper disable once CompareOfFloatsByEqualityOperator
			if (_groundSensorWidth == 0)
				_groundSensorWidth = _playerSprite.rect.width / _playerSprite.pixelsPerUnit * transform.localScale.x;
			else
				_groundSensorWidth *= transform.localScale.x;

			#region Input

			inputHandler = GetComponent<InputHandler>();

			#endregion

			#region Physics

			rb = GetComponent<Rigidbody2D>();
			boxCollider2D = GetComponent<BoxCollider2D>();

			#endregion
		}

		// FixedUpdate is called at regular time intervals independent of framerate
		public void FixedUpdate()
		{
			// Check if player is on the ground
			isGrounded = IsGrounded();

			if (isGrounded)
			{
				rb.AddForce(Vector2.right * inputHandler.x * moveSpeed * Time.fixedDeltaTime);
				rb.AddForce(Vector2.right * -rb.velocity.x * frictionCoefficient * frictionMultiplier);
				Debug.DrawRay(transform.position,
					Vector2.right * -rb.velocity.x * frictionCoefficient * frictionMultiplier,
					Color.red);
			}
			else
			{
				// Additional gravity
				rb.AddForce(Vector2.down * 10);

				// Add horizontal movement
				rb.AddForce(Vector2.right * inputHandler.x * moveSpeed * Time.deltaTime / 2f);
			}


			// If horizontal velocity is above maxSpeed, set horizontal velocity to maxSpeed
			if (Math.Abs(rb.velocity.x) > maxMoveSpeed)
				rb.velocity = new Vector2(maxMoveSpeed * Math.Sign(rb.velocity.x), rb.velocity.y);

			if (Math.Abs(rb.velocity.y) > terminalVelocity)
				rb.velocity = new Vector2(rb.velocity.x, terminalVelocity * Math.Sign(rb.velocity.y));
		}

		public void LateUpdate()
		{
			#region Jumping

			// If space is pressed
			if (inputHandler.jump)
			{
				// If player is on ground, just jump straight up
				if (isGrounded)
				{
					Jump(1f / jumpDampener);
					isGrounded = false;
				}
			}

			#endregion
		}

		#region Jumping and ground checking

		public void Jump(float multiplier = 1f) =>
			rb.AddForce(Vector2.up * jumpForce * multiplier, ForceMode2D.Impulse);

		public bool IsGrounded()
		{
			return Physics2D.OverlapArea(
				new Vector2(transform.position.x - _groundSensorWidth / 2,
					transform.position.y - .16f),
				new Vector2(transform.position.x + _groundSensorWidth / 2,
					transform.position.y - .16f - ExtraHeight),
				groundLayer);
		}

		#endregion

		public void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(transform.position,
				new Vector2(.32f * transform.localScale.x, .32f * transform.localScale.y));

			// Ground
			Gizmos.color = isGrounded ? Color.green : Color.red;
			Gizmos.DrawWireCube(
				new Vector2(transform.position.x,
					transform.position.y - .16f * transform.localScale.y - ExtraHeight / 2),
				new Vector2(_groundSensorWidth, ExtraHeight));
		}
	}
}