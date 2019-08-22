using System.Collections;
using KG.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KG.UI
{
    public class ButtonBehaviour : MonoBehaviour
    {
        private FadeController _fadeController;

        private void Start()
        {
            _fadeController = GetComponent<FadeController>();
        }

        public void LoadScene(int sceneId)
        {
            _fadeController.Scale();
            StartCoroutine(LoadLevel(sceneId));
        }

        public void ShowWindow(GameObject window)
        {
            window.SetActive(true);
        }

        public void HideWindow(GameObject window)
        {
            window.SetActive(false);
        }

        public void ToggleWIndow(GameObject window)
        {
            if (window.activeSelf)
            {
                window.SetActive(false);
            }
            else
            {
                window.SetActive(true);
            }

            GameManager.GameIsPaused = !GameManager.GameIsPaused;
        }

        public static IEnumerator LoadLevel(int sceneId)
        {
            var sceneLoadDelay = 1;
            yield return new WaitForSeconds(sceneLoadDelay);
            SceneManager.LoadScene(sceneId);
        }
    }
}