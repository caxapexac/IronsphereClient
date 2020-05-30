using UnityEngine;
using UnityEngine.EventSystems;


namespace GuiComponents
{
    public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Vector2 _startPosition;
        private Vector2 _startMousePosition;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = transform.position;
            _startMousePosition = Input.mousePosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = _startPosition - _startMousePosition + (Vector2)Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Debug.Log("Drag Ended");
        }
    }
}