using DG.Tweening;
using UnityEngine;

namespace KG.Gameplay
{
    public class InteractableObjectMovement : MonoBehaviour
    {
        [SerializeField] private float offset = 0.5f;
        [SerializeField] private Vector2 correctPosition;


        private Vector2 _startingPosition;
        private Vector3 _position;
        private Animator _animator;
        private bool _following;
        private bool _inCorrectPosition;

        private static Transform _anchor;

        private static Transform Anchor
        {
            get
            {
                if (_anchor != null) return _anchor;
                var newAnchor = new GameObject("Anchor");
                _anchor = newAnchor.transform;
                return _anchor;
            }
        }

        public float Offset => offset;

        private void Start()
        {
            _startingPosition = transform.position;
            transform.SetParent(Anchor, true);
        }

        public bool IsInCorrectPosition()
        {
            return _inCorrectPosition;
        }

        public Vector2 GetStartingPosition()
        {
            return _startingPosition;
        }

        public Vector2 GetCorrectPosition()
        {
            return correctPosition;
        }

        public void MoveTo(Vector3 position)
        {
            if (transform != null) transform.DOMove(position, 0.2f);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            var sameTag = other.CompareTag(tag);
            if (!sameTag) return;
            _inCorrectPosition = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var sameTag = other.CompareTag(tag);
            if (!sameTag) return;
            _inCorrectPosition = false;
        }
    }
}