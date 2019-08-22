using UnityEngine;
using UnityEngine.UI;

namespace KG.UI
{
    [RequireComponent(typeof(ButtonBehaviour))]
    [RequireComponent(typeof(FadeController))]
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private GameObject winScreenParticles;
        [SerializeField] private GameObject winScreenButton;
        [SerializeField] private Image      winFadeImage;
        [Range(0f, 1f)]
        [SerializeField]
        private float winFadeAmount;

        private ButtonBehaviour _buttonBehaviour;
        private FadeController  _fadeController;

        private void Awake()
        {
            _fadeController = GetComponent<FadeController>();
            _buttonBehaviour = GetComponent<ButtonBehaviour>();
        }

        private void ToggleParticles()
        {
            winScreenParticles.SetActive(!winScreenParticles.activeSelf);
        }

        private void ToggleWinButton()
        {
            _buttonBehaviour.ToggleWIndow(winScreenButton);
        }

        public void ToggleWinScreen()
        {
            FadeOutScreen();
            ToggleParticles();
            ToggleWinButton();
        }

        private void FadeOutScreen()
        {
            winFadeImage.gameObject.SetActive(!winFadeImage.gameObject.activeSelf);
            _fadeController.Fade(winFadeImage, winFadeAmount);
        }
    }
}