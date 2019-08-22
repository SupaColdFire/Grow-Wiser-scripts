using UnityEngine;

namespace KG.Gameplay
{
    public class InputSystem : MonoBehaviour
    {
        [SerializeField] protected Camera cam;

        protected Vector3 PointerPosition;
        protected bool    PointerPressed;

        public Vector3 GetPointerPosition()
        {
            return PointerPosition;
        }

        public bool IsPointerPressed()
        {
            return PointerPressed;
        }

        private void Update()
        {
            ProcessInput();
        }

        protected virtual void ProcessInput()
        {
        }
    }
}