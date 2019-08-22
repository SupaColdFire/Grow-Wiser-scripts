using UnityEngine;

namespace KG.Gameplay
{
    public class MouseInputSystem : InputSystem
    {
        protected override void ProcessInput()
        {
            PointerPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            PointerPosition.z = 0f;
            PointerPressed = Input.GetMouseButton(0);
        }
    }
}