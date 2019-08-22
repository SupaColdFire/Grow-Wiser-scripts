using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private bool  scrollLeft = true;
    private bool _isScrolling = true;
    private float _scrollSpeedDefault;
    private float   _backgroundLength;
    private Vector3 _startPosition;

    private void Start()
    {
        _scrollSpeedDefault = scrollSpeed;
        var backgroundTransform = transform;
        _backgroundLength = GetComponent<SpriteRenderer>().size.x * backgroundTransform.localScale.x;
        _startPosition = backgroundTransform.position;
    }

    private void Update()
    {
        var scrollDirection = scrollLeft ? 1 : -1;
        var offset          = Mathf.Repeat( Time.time * scrollSpeed, _backgroundLength);
        transform.position = _startPosition + Vector3.left * offset * scrollDirection;
    }

    public void BackgroundSpeedChanged()
    {
        if (_isScrolling)
        {
            Debug.Log("Speed is set to 0");
            scrollSpeed = 0;
            _isScrolling = false;
        }
        else
        {
            Debug.Log($"Speed is set to {_scrollSpeedDefault}");
            scrollSpeed = _scrollSpeedDefault;
            _isScrolling = true;
        }    
    }
}