using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputControllerSlider : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public UnityEvent EventUp;
    public UnityEvent EventDown;
    public enum Direction { Left, Up, Right, Down, None }

    Direction direction;
    Vector2 startPos, endPos;
    public float swipeThreshold = 10f;
    bool draggingStarted;

    private void Awake()
    {
        draggingStarted = false;
        direction = Direction.None;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingStarted = true;
        startPos = eventData.pressPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggingStarted)
        {
            endPos = eventData.position;

            Vector2 difference = endPos - startPos; // difference vector between start and end positions.

            if (difference.magnitude > swipeThreshold)
            {
                if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y)) // Do horizontal swipe
                {
                    direction = difference.x > 0 ? Direction.Right : Direction.Left; // If greater than zero, then swipe to right.
                }
                else //Do vertical swipe
                {
                    direction = difference.y > 0 ? Direction.Up : Direction.Down; // If greater than zero, then swipe to up.
                }
            }
            else
            {
                direction = Direction.None;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggingStarted && direction != Direction.None)
        {
            //Do something with this direction data.
            Debug.Log("Swipe direction: " + direction);

            switch (direction)
            {
                case Direction.Up:
                    EventUp.Invoke();
                    break;
                case Direction.Down:
                    EventDown.Invoke();
                    break;
            }
            
        } 

        //reset the variables
        startPos = Vector2.zero;
        endPos = Vector2.zero;
        draggingStarted = false;
    }

}

// https://mstfmrt07.medium.com/swipe-detection-in-unity-5e8dc7a6fe17 - это там где я спиздил данный скрипт