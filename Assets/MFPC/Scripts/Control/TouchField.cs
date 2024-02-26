using UnityEngine;
using UnityEngine.EventSystems;

namespace MFPC
{
    public class TouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        /// <summary>
        /// The distance between the position of the wheelbarrow on the previous frame and the current one
        /// </summary>
        public Vector2 GetSwipeDirection
        {
            get => new Vector2(touchDist.x, -touchDist.y);
        }

        private Vector2 touchDist;
        private Vector2 pointerOld;
        private bool isPressed;
        
        private int pointerId;

        private void FixedUpdate()
        {
            if (isPressed)
            {
                //Find the distance between the position of the wheelbarrow on the previous frame and the current one
                if (pointerId >= 0 && pointerId < UnityEngine.Input.touches.Length)
                {
                    touchDist = UnityEngine.Input.touches[pointerId].position - pointerOld;
                    pointerOld = UnityEngine.Input.touches[pointerId].position;
                }
                else
                {
                    touchDist =
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y) - pointerOld;
                    pointerOld = UnityEngine.Input.mousePosition;
                }

            }
            else touchDist = new Vector2();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
            pointerOld = eventData.position;
            pointerId = eventData.pointerId;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;

            touchDist = Vector2.zero;
        }
    }
}