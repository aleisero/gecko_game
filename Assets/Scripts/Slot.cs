using UnityEngine;
using UnityEngine.EventSystems;

//Tutorial on Inventory System: https://www.youtube.com/watch?v=c47QYgsJrWc

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if(transform.childCount>0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
        }
    }
}
