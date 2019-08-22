using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer fadeImage;
    [Header("Fade Settings")]
    [SerializeField]private float fadeDuration = 1f;
    [SerializeField]private float scaleDuration = 1f;

    private float _scaleValue;
    private float _minScale = 0;
    private float _maxScale = 30;

    private void Awake()
    {
        if (fadeImage.transform.localScale.x > 1)
        {
            _maxScale = fadeImage.transform.localScale.x;
        }
    }

    private void Start()
    {
        DOTween.Init();
    }

    public void Fade(Image fadeImage, float fadeToAmount)
    {
        fadeImage.DOFade(fadeToAmount, fadeDuration);
    }


    public void Scale()
    {
        _scaleValue = fadeImage.transform.localScale.x;
        if (Mathf.Approximately(Mathf.Abs(_scaleValue - _minScale), 0f))
        {
            fadeImage.transform.DOScale(_maxScale, scaleDuration);
        }
        else if (Mathf.Approximately(Mathf.Abs(_scaleValue - _maxScale), 0f))
        {
            fadeImage.transform.DOScale(_minScale, scaleDuration);
        }
    }

    public void ToggleImage()
    {
        fadeImage.gameObject.SetActive(fadeImage.gameObject);
    }
}