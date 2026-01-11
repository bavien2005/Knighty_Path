using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum Direction { Left, Right }
    public Direction moveDirection;

    private bool isHeld = false;

    void Update()
    {
        if (isHeld)
        {
            if (moveDirection == Direction.Left)
            {
                MobileInput.horizontal = -1;
            }
            else
            {
                MobileInput.horizontal = 1;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeld = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHeld = false;
        MobileInput.horizontal = 0;
    }
}
