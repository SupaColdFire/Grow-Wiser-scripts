using System.Collections;
using KG.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KG.Gameplay
{
    [RequireComponent(typeof(InputSystem))]
    [RequireComponent(typeof(AudioManager))]
    [RequireComponent(typeof(ParticleController))]
    [RequireComponent(typeof(FadeController))]
    [RequireComponent(typeof(InteractableObjectsController))]
    [RequireComponent(typeof(WinScreen))]
    public class GameManager : MonoBehaviour
    {
        private        float                         _sceneLoadDelay;
        private        AudioManager                  _audioManager;
        private        FadeController                _fadeController;
        private        InteractableObjectsController _objectsController;
        private        WinScreen                     _winScreen;
        private static bool                          _gameIsOver;


        public static bool GameIsPaused { get; set; }


        private void Awake()
        {
             _audioManager = GetComponent<AudioManager>();
            _fadeController = GetComponent<FadeController>();
            _objectsController = GetComponent<InteractableObjectsController>();
            _winScreen = GetComponent<WinScreen>();
        }

        private void Start()
        {
            _gameIsOver = false;
            GameIsPaused = false;
            _fadeController.ToggleImage();
            _fadeController.Scale();
            _sceneLoadDelay = _audioManager.GetWinAudioLength();
        }

        private void Update()
        {
            if (!GameIsPaused)
            {
                _objectsController.MoveAndPlaceInteractableObjects();
            }

            CheckForGameOver();
        }


        private void CheckForGameOver()
        {
            if (_gameIsOver || _objectsController.InteractableObjectCount != 0) return;
            _gameIsOver = true;
            ShowWinScreen();
        }

        private void ShowWinScreen()
        {
            _winScreen.ToggleWinScreen();
        }

        private static int GetNextLevelId()
        {
            var noOfScenes   = SceneManager.sceneCountInBuildSettings;
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            int result;
            if (currentScene < noOfScenes - 1)
            {
                result = currentScene + 1;
            }
            else
            {
                result = 1;
            }

            return result;
        }


        public void LoadLevelCoroutine()
        {
            StartCoroutine(LoadLevel());
        }

        private IEnumerator LoadLevel()
        {
            _audioManager.PlayWinAudio();
            _fadeController.Scale();
            yield return new WaitForSeconds(_sceneLoadDelay);
            SceneManager.LoadScene(GetNextLevelId());
        }
    }
}