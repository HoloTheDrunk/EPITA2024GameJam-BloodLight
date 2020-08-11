using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI_and_Camera.Menus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource = null;

        public void Play()
        {
            _audioSource.Play();
            SceneManager.LoadScene("Level 1");
        }

        public void Options()
        {
            _audioSource.Play();
            Camera.main.GetComponent<MenuState>().SetState(1);
        }

        public void Quit()
        {
            _audioSource.Play();
            Application.Quit();
        }
    }
}
