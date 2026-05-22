using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//purpose: identify which accessory this is, what thew grad sprite looks like, and change it to the placeed sprite 
//usage: place on the accessories themselves? 
public class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentAfterDrag;
    public Image spriteImage;
    public AccessoryOption spriteOptions;
    Camera cam;
     public void Start(){
          cam = Camera.main;
          if (!spriteOptions.defaultSprite){
               Debug.LogError(gameObject.name + " does not have a valid default sprite");
          }
          
          spriteImage.sprite = spriteOptions.defaultSprite;
     }

    // Start is called before the first frame update
   public void OnBeginDrag(PointerEventData eventData)
   {
        Debug.Log("Begin Dragging");
        if (!spriteOptions.heldSprite){
               Debug.LogError(gameObject.name + " does not have a valid held sprite");
          }
        spriteImage.sprite = spriteOptions.heldSprite;
        parentAfterDrag = transform.parent; // if the item is in a panel or grid to be placed, then make sure to unparent
        transform.SetParent(transform.root);
        transform.SetAsLastSibling(); // place on top of all of the other UI elements so it doesnt clip through
   }
   public void OnDrag(PointerEventData eventData)
   {    
        Debug.Log("Dragging");
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition; // while we're dragging, make sure to follow the mouse on the screen

   }
   public void OnEndDrag(PointerEventData eventData)
   {
     spriteImage.sprite = spriteOptions.defaultSprite;
        Debug.Log("END Dragging");
        transform.SetParent(parentAfterDrag); // reparent the item to the panel/grid its on 
        //add a bool for "change after drag and for specific accessories make sure to set which ones chanage and which dont "

   }
}
