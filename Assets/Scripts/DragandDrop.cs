using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragandDrop : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    // Start is called before the first frame update

    [SerializeField] private RectTransform dragRectTransform;
    float DragXPos, DragYPos;
    [SerializeField] private Canvas canvas;

    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        if (dragRectTransform == null)
        {
            dragRectTransform = transform.parent.GetComponent<RectTransform>();
        }
        if (canvas == null)
        {
            Transform testCanvasTransform = transform.parent;
            while (testCanvasTransform != null) //if empty, grab the nearest and most vaialbale canvas
            {
                
                canvas = testCanvasTransform.GetComponent<Canvas>();
                if (canvas != null)
                {
                    break;
                }
                testCanvasTransform = testCanvasTransform.parent;
            }
        }
    }
 
   
        void IDragHandler.OnDrag(PointerEventData eventData) // as youre draggging the mouse
    {
        
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //grabs mvmt form previous mouse pos
        //windowpos.y = Mathf.Clamp(windowpos.y, 30, 15);
        Debug.Log("PlayerDraggingMouse");
    }
    public void OnPointerDown(PointerEventData eventData) // as you click and hold 
    {
        dragRectTransform.SetAsLastSibling();

        Debug.Log("everythingOnTop");
    }
}
