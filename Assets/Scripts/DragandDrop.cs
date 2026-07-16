using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // lets us implement interface interactions

//PURPOSE: Test script for the drag and drop but specifially for sprites and not ui images 
//USAGE:
public class DragandDrop : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update

   public Transform parentAfterDrag;
    public SpriteRenderer spriteImage;
    public AccessoryOption spriteOptions;
    public bool returnToDefault; // does the sprite return to how it was picked up or no 
    public GameObject butterfly;
    public GameObject butterflyBtn;
    public Transform handPanel;
    public Transform accessoryPanel;
    Camera cam;
    public Vector2 startingPos;

     public void Start()
     {
        startingPos = new Vector2 (GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
        Debug.Log(startingPos);
          cam = Camera.main;
          if (!spriteOptions.defaultSprite)
          {
               Debug.LogError(gameObject.name + " does not have a valid default sprite");
          }
          
         spriteImage.sprite = spriteOptions.defaultSprite;
     }

    // Start is called before the first frame update
   public void OnBeginDrag(PointerEventData eventData)
   {
        Debug.Log("Begin Dragging");
        if (!spriteOptions.heldSprite)
        {
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
     Debug.Log("END Dragging");
     transform.SetParent(handPanel); // reparent the item to the panel/grid its on 
        //if the accessory was placed within bounds, put it in the hand panel
        // else if the accessory is not within bounds, reparent it back, and snap it to the original position


        //bool for "change after drag and for specific accessories make sure to set which ones chanage and which dont 
        if (returnToDefault == true)
         {
            spriteImage.sprite = spriteOptions.defaultSprite;  
            transform.SetParent(handPanel);
         }
   }
 public void OnTriggerStay2D(Collider2D collision) // as long as the accessory is in bounds, do this
    {

        Debug.Log("I AM CONNECTING Stay");
        transform.SetParent(handPanel);
    }
    public void OnTriggerExit2D(Collider2D exit) //when the accessory leaves bounds, do this
    {
        Debug.Log("iM NO LONGER CONNECTED, exit");
        transform.SetParent(accessoryPanel);
    }

    public void ButterflyFlyAway()
   {
     butterfly.SetActive(true); //just show the butterfly dog 
     butterflyBtn.SetActive(false);
   }
   
    
    }

