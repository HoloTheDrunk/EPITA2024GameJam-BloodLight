using UnityEngine;

namespace Assets.Scripts
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance;

		[SerializeField] private bool _isCheating;

		public bool IsCheating => _isCheating;

		public void Awake()
		{
			if (instance == null)
				instance = this;
			if (instance != this)
				Destroy(gameObject);
			
			DontDestroyOnLoad(instance);
		}

		public void ToggleCheating() => _isCheating = !_isCheating;
	}
}