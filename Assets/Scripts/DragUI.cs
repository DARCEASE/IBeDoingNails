using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentAfterDrag;
    // Start is called before the first frame update
   public void OnBeginDrag(PointerEventData eventData)
   {
        Debug.Log("Begin Dragging");
        parentAfterDrag = transform.parent; // if the item is in a panel or grid to be placed, then make sure to unparent
        transform.SetParent(transform.root);
        transform.SetAsLastSibling(); // place on top of all of the other UI elements so it doesnt clip through
   }
   public void OnDrag(PointerEventData eventData)
   {    
        Debug.Log("Dragging");
        transform.position = Input.mousePosition; // while we're dragging, make sure to follow the mouse on the screen

   }
   public void OnEndDrag(PointerEventData eventData)
   {
        Debug.Log("END Dragging");
        transform.SetParent(parentAfterDrag); // reparent the item to the panel/grid its on 

   }
}
