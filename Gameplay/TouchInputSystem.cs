using UnityEngine;

namespace KG.Gameplay
{
    public class TouchInputSystem : InputSystem
    {
        protected override void ProcessInput()
        {
            if (Input.touchCount > 0)
            {
                PointerPosition = cam.ScreenToWorldPoint(Input.touches[0].position);
                PointerPosition.z = 0f;
                PointerPressed = true;
            }
            else
            {
                PointerPressed = false;
            }
        }
    }
}