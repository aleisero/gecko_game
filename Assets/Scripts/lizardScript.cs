using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lizardScript : MonoBehaviour
{
    public GameObject hide;
    private List<string> InvList = DragHandler.InvList;

    //called from DragHandler
    public void TankWithHide()
    {
        //put lizard in same slot as hide
        transform.position = hide.transform.parent.position;
        //make lizard not clickable or visible
        this.GetComponent<CanvasGroup>().alpha = 0f;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //called from DragHandler
    public void TankWithoutHide()
    {
        //make lizard not clickable
        this.GetComponent<CanvasGroup>().alpha = 1f;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //called from dialgueHandler
    public void LizardViz()
    {
        //make lizard visible and clickable
        this.GetComponent<CanvasGroup>().alpha = 1f;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //move to front
        //https://answers.unity.com/questions/874238/unity-46-ui-bring-element-in-front.html
        Transform canvas = transform.parent.transform.parent.transform.parent;
        this.transform.parent = canvas;
        this.transform.SetAsLastSibling();
    }

}
