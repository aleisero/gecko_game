using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Tutorial on Inventory System: https://www.youtube.com/watch?v=c47QYgsJrWc

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;

    public static List<string> InvList = new List<string>();

    public void OnBeginDrag (PointerEventData evenData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }

        if (GetComponent<CanvasGroup>().transform.parent.transform.parent.name == "Inventory")
        {
            //Debug.Log(GetComponent<CanvasGroup>().gameObject);
            InvList.Add(GetComponent<CanvasGroup>().gameObject.name);
            //Debug.Log(InvList[0]);
        }

    }
    
}
