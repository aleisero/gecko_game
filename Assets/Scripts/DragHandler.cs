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
    public static List<string> TankList = new List<string>();

    private GameObject lizard;

    public void Start()
    {
        lizard = GameObject.Find("Lizard");
        InvList.Clear();
        TankList.Clear();

        InvList.Add("Lizard");
    }

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
            InvList.Add(GetComponent<CanvasGroup>().gameObject.name);
            TankList.Remove(GetComponent<CanvasGroup>().gameObject.name);
        }
        

        if (GetComponent<CanvasGroup>().transform.parent.transform.parent.name == "Store")
        {  
            //remove from list
            //InvList.Remove(GetComponent<CanvasGroup>().gameObject.name);
            for (int i = 0; i < InvList.Count; i++)
            {
                if (InvList[i] == GetComponent<CanvasGroup>().gameObject.name)
                {
                    InvList.RemoveAt(i);
                    break;
                }
            }
        }

        if (GetComponent<CanvasGroup>().transform.parent.transform.parent.name == "Tank")
        {
            //add to tankList and remove from InvList
            TankList.Add(GetComponent<CanvasGroup>().gameObject.name);
            InvList.Remove(GetComponent<CanvasGroup>().gameObject.name);

            if (GetComponent<CanvasGroup>().name == "Lizard")
            {
                if (TankList.Contains("Hide"))
                {
                    lizard.GetComponent<lizardScript>().TankWithHide();
                    //SFX: scurrying lizard noise
                }
                else if (InvList.Contains("Hide"))
                {
                    lizard.GetComponent<lizardScript>().TankWithoutHide();
                }
            }

            if (GetComponent<CanvasGroup>().name == "Hide" && TankList.Contains("Lizard"))
            {
                lizard.GetComponent<lizardScript>().TankWithHide();
            }
        }

    }
}
