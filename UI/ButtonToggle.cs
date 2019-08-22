using UnityEngine;
using UnityEngine.UI;

namespace KG.UI
{
    public class ButtonToggle : MonoBehaviour
    {
        [SerializeField] private Sprite[] toggleSprites;

        private Image _currentImage;

        private void Start()
        {
            _currentImage = GetComponent<Image>();
        }

        public void SwapSprite()
        {
            var sprite = _currentImage.sprite;
            if (sprite == toggleSprites[0])
            {
                _currentImage.sprite = toggleSprites[1];
            }
            else
            {
                _currentImage.sprite = toggleSprites[0];
            }
        }
    }
}